namespace Draft_Diamond_BD
{
    public partial class WarehouseAdmin : Form
    {
        private DataGridView dgvWarehouseTrue;
        private string userLogin;
        private List<double> _seasonPercents = new();
        public WarehouseAdmin(string login)
        {
            InitializeComponent();
            userLogin = login;
            labelLogin.Text = "Логин:" + userLogin;
            CreateDataGridView();
            Task.Run(async () => await LoadProductsTrueAsync()).Wait();
            FilterProducts();

            весьСкладToolStripMenuItem.Click += async (s, a) => await LoadProductsTrueAsync();
            exitToolStripMenuItemOutput.Click += Exit_Click;

            AppCurrencyManager.CurrencyChanged += async (s, e) => await LoadProductsTrueAsync();

            Logger.UserAction(userLogin, "Открыта форма администратора склада");
        }
        private void CreateDataGridView()
        {
            dgvWarehouseTrue = new DataGridView
            {
                Location = new System.Drawing.Point(20, 90),
                Size = new System.Drawing.Size(1060, 540),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Font = new System.Drawing.Font("Segoe UI", 10F),
            };
            dgvWarehouseTrue.CellFormatting += DgvWarehouseTrue_CellFormatting;
            Controls.Add(dgvWarehouseTrue);
        }
        private void DgvWarehouseTrue_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _seasonPercents.Count) return;
            double percent = _seasonPercents[e.RowIndex];
            var row = dgvWarehouseTrue.Rows[e.RowIndex];
            System.Drawing.Color color;
            if (percent > 50)
                color = System.Drawing.Color.FromArgb(144, 238, 144);
            else if (percent >= 25)
                color = System.Drawing.Color.FromArgb(255, 255, 102);
            else
                color = System.Drawing.Color.FromArgb(255, 102, 102);
            row.DefaultCellStyle.BackColor = color;
            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(
                color.R - 20 < 0 ? 0 : color.R - 20,
                color.G - 20 < 0 ? 0 : color.G - 20,
                color.B - 20 < 0 ? 0 : color.B - 20);
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
        public async Task LoadProductsTrueAsync()
        {
            Logger.UserAction(userLogin, "Загрузка активных товаров");
            await using var db = new AllDB();
            await UpdateExpiredProductsStatusAsync();
            var raw = await db.Products.Where(p => p.Status == true).ToListAsync();
            BindProductsWithPercents(raw);
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
        private void SetupColumnsTrue()
        {
            foreach (DataGridViewColumn col in dgvWarehouseTrue.Columns)
                col.HeaderText = col.HeaderText.Replace("_", " ");
        }
        private void AddCardToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы добавления карточки");
            var addCardForm = new AddCard(userLogin);
            addCardForm.Show();
        }
        private void newCategoryToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы добавления категории");
            var addCategoryForm = new AddCategory(userLogin);
            addCategoryForm.Show();
        }
        private void Exit_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Выход из приложения");
            Application.Exit();
        }
        private void changeAccountToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Смена аккаунта");
            var authForm = new Authorization();
            authForm.Show();
            Close();
        }
        private void changeCardToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы изменения карточки");
            var changeCardForm = new ChangeCard(userLogin);
            changeCardForm.Show();
        }
        private void CategoryChangeToolStripMenuItem1_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы изменения категории");
            var changeCategoryForm = new ChangeCategory(userLogin);
            changeCategoryForm.Show();
        }
        private void deleteCardToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы удаления карточки");
            var deleteCardForm = new DeleteCard(userLogin);
            deleteCardForm.Show();
        }
        private void deleteCategoryToolStripMenuItem2_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы удаления категории");
            var deleteCategoryForm = new DeleteCategory(userLogin);
            deleteCategoryForm.Show();
        }
        private void buttonHistoryShipment_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие истории отгрузок");
            var historyForm = new HistoryShipmentForm(userLogin);
            historyForm.Show();
        }
        private void buttonWrittenOff_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие склада списанных товаров");
            var writtenOffForm = new WrittenOffForm(userLogin);
            writtenOffForm.Show();
        }
        private void toolStripMenuItemCollections_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы сезонных коллекций");
            var collectionsForm = new SeasonalCollectionsForm(userLogin);
            collectionsForm.Show();
        }
        private void toolStripMenuItemCurrency_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие настроек валюты");
            var currencyForm = new CurrencySettings(userLogin);
            currencyForm.ShowDialog();
        }
        private void принятьПоставкуToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(userLogin, "Открытие формы приёмки поставки");
            var acceptanceForm = new AcceptanceOfGoodsForm(userLogin);
            acceptanceForm.Show();
        }
    }
}