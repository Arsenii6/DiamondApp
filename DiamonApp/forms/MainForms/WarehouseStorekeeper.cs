namespace Draft_Diamond_BD
{
    public partial class WarehouseStorekeeper : Form
    {
        private DataGridView dgvWarehouseTrue;
        private DataGridView dgvWarehouseFalse;
        private string userLogin;
        private List<double> _seasonPercents = new();
        public WarehouseStorekeeper(string login)
        {
            InitializeComponent();
            userLogin = login;
            labelLogin.Text = Resources.LoginInMenu + userLogin;
            FilterProducts();
            CreateDataGridViewTrue();
            CreateDataGridViewFalse();
            Task.Run(async () => await LoadProductsTrueAsync()).Wait();
            весьСкладToolStripMenuItem.Click += async (s, e) => await LoadProductsTrueAsync();
            exitToolStripMenuItemOutput.Click += Exit_Click;
            createShipmentToolStripMenuItem.Click += CreateShipmentToolStripMenuItem_Click;
            принятьПоставкуToolStripMenuItem.Click += принятьПоставкуToolStripMenuItem_Click;
            toolStripMenuItemCurrency.Click += buttonCurrencySettings_Click;
            сменитьАккаунтToolStripMenuItem.Click += changeAccountToolStripMenuItem_Click;
            AppCurrencyManager.CurrencyChanged += async (s, e) => await LoadProductsTrueAsync();

            Logger.UserAction(userLogin, "Открыта форма кладовщика");
        }
        private void CreateDataGridViewTrue()
        {
            dgvWarehouseTrue = new DataGridView
            {
                Location = new System.Drawing.Point(20, 90),
                Size = new System.Drawing.Size(1060, 280),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Font = new System.Drawing.Font("Segoe UI", 10F),
            };
            dgvWarehouseTrue.CellFormatting += DgvWarehouseTrue_CellFormatting;
            Controls.Add(dgvWarehouseTrue);
        }
        private void CreateDataGridViewFalse()
        {
            dgvWarehouseFalse = new DataGridView
            {
                Location = new System.Drawing.Point(20, 420),
                Size = new System.Drawing.Size(1060, 240),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Font = new System.Drawing.Font("Segoe UI", 10F),
            };
            Controls.Add(dgvWarehouseFalse);
            var lbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 390),
                Text = "Списанные товары:"
            };
            Controls.Add(lbl);
        }
        private void FilterProducts()
        {
            Logger.UserAction(userLogin, "Фильтрация продуктов по категориям");
            using var db = new AllDB();
            foreach (var cat in db.Categories.ToList())
            {
                foreach (var category in cat.NamesOfCategory)
                {
                    var alreadyExists = false;
                    foreach (ToolStripMenuItem existingItem in категорииToolStripMenuItem.DropDownItems)
                    {
                        if (existingItem.Text == category) { alreadyExists = true; break; }
                    }
                    if (alreadyExists) continue;

                    var menuItem = new ToolStripMenuItem(category);
                    menuItem.Click += async (s, e) =>
                    {
                        Logger.UserAction(userLogin, $"Фильтрация по категории: {category}");
                        await using var db = new AllDB();
                        var raw = await db.Products.Where(p => p.Category == category && p.Status == true).ToListAsync();
                        BindProductsWithPercents(raw);
                    };
                    категорииToolStripMenuItem.DropDownItems.Add(menuItem);
                }
            }
        }
        private async Task UpdateExpiredProductsStatusAsync()
        {
            await using var db = new AllDB();
            var expiredProducts = await db.Products
                .Where(p => p.EndDateOfTheDay < DateTime.Today && p.Status)
                .ToListAsync();

            foreach (var product in expiredProducts)
            {
                product.Status = false;
                Logger.UserAction(userLogin, $"Товар '{product.Name}' просрочен");
            }

            await db.SaveChangesAsync();
        }
        public async Task LoadProductsTrueAsync()
        {
            Logger.UserAction(userLogin, "Загрузка активных товаров");
            await using var db = new AllDB();
            await UpdateExpiredProductsStatusAsync();
            var raw = await db.Products.Where(p => p.Status == true).ToListAsync();
            BindProductsWithPercents(raw);
            await LoadProductsFalseAsync();
        }
        private void BindProductsWithPercents(List<ProductClass> products)
        {
            _seasonPercents.Clear();

            var display = products.Select(p =>
            {
                int daysLeft = (int)(p.EndDateOfTheDay - DateTime.Today).TotalDays;
                int totalDays = p.UntilTheEndOfTheSeason * 7;
                double percent;
                if (totalDays > 0)
                    percent = (double)daysLeft / totalDays * 100.0;
                else
                    percent = daysLeft > 0 ? Math.Min((double)daysLeft / 365.0 * 100.0, 100.0) : 0;

                if (percent < 0) percent = 0;
                _seasonPercents.Add(percent);
                return new
                {
                    Название = p.Name,
                    Единица_измерения = p.UniteOfMeasure,
                    Цена_закупки = AppCurrencyManager.Format(p.PurchasePrice),
                    Текущий_остаток = p.Rest,
                    Сезон_до = p.EndDateOfTheDay.ToString("d"),
                    До_конца = p.UntilTheEndOfTheSeason,
                    Скидка = p.Discount,
                    Итоговая_стоимость = AppCurrencyManager.Format(p.FinalyPrice),
                };
            }).ToList();
            dgvWarehouseTrue.DataSource = display;
            SetupColumnsTrue();
        }
        private void DgvWarehouseTrue_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _seasonPercents.Count) return;

            double percent = _seasonPercents[e.RowIndex];
            System.Drawing.Color color;
            if (percent > 50)
                color = System.Drawing.Color.FromArgb(144, 238, 144);
            else if (percent >= 25)
                color = System.Drawing.Color.FromArgb(255, 255, 102);
            else
                color = System.Drawing.Color.FromArgb(255, 102, 102);
            var row = dgvWarehouseTrue.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = color;
            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(
                Math.Max(0, color.R - 20),
                Math.Max(0, color.G - 20),
                Math.Max(0, color.B - 20));
        }
        private void SetupColumnsTrue()
        {
            foreach (DataGridViewColumn col in dgvWarehouseTrue.Columns)
                col.HeaderText = col.HeaderText.Replace("_", " ");
        }
        public async Task LoadProductsFalseAsync()
        {
            Logger.UserAction(userLogin, "Загрузка просроченных товаров");
            await using var db = new AllDB();
            var productsFalse = await db.Products.Where(p => p.Status == false).ToListAsync();

            if (productsFalse.Any())
            {
                var productsload = productsFalse.Select(p => new
                {
                    p.Name,
                    p.UniteOfMeasure,
                    p.Category,
                    p.Rest,
                    p.EndDateOfTheDay,
                    Итоговая_стоимость = AppCurrencyManager.Format(p.FinalyPrice),
                }).ToList();
                dgvWarehouseFalse.DataSource = productsload;
                SetupColumnsFalse();
            }

            decimal sum = productsFalse.Sum(p => p.FinalyPrice);
            labelResult.Text = Resources.Result + AppCurrencyManager.Format(sum);
            Logger.UserAction(userLogin, $"Сумма просроченных товаров: {sum}");
        }
        private void SetupColumnsFalse()
        {
            if (dgvWarehouseFalse.Columns["Name"] != null)
                dgvWarehouseFalse.Columns["Name"].HeaderText = "Название";
            if (dgvWarehouseFalse.Columns["UniteOfMeasure"] != null)
                dgvWarehouseFalse.Columns["UniteOfMeasure"].HeaderText = "Единица измерения";
            if (dgvWarehouseFalse.Columns["Category"] != null)
                dgvWarehouseFalse.Columns["Category"].HeaderText = "Категория";
            if (dgvWarehouseFalse.Columns["Итоговая_стоимость"] != null)
                dgvWarehouseFalse.Columns["Итоговая_стоимость"].HeaderText = "Убыток";
            if (dgvWarehouseFalse.Columns["Rest"] != null)
                dgvWarehouseFalse.Columns["Rest"].HeaderText = "Остаток";
            if (dgvWarehouseFalse.Columns["EndDateOfTheDay"] != null)
                dgvWarehouseFalse.Columns["EndDateOfTheDay"].HeaderText = "Дата окончания";
        }
        private void CreateShipmentToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы создания отгрузки");
            new CreatingShipmentForm(userLogin).Show();
        }
        private void Exit_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Выход из приложения");
            Application.Exit();
        }
        private void changeAccountToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Смена аккаунта");
            new Authorization().Show();
            Close();
        }
        private void buttonCurrencySettings_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие настроек валюты");
            var currencyForm = new CurrencySettings(userLogin);
            currencyForm.ShowDialog();
        }
        private void принятьПоставкуToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы приёмки поставки");
            new AcceptanceOfGoodsForm(userLogin).Show();
        }
    }
}