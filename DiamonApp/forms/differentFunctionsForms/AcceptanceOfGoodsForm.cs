namespace DiamondApp.forms.differentFunctionsForms
{
    public partial class AcceptanceOfGoodsForm : Form
    {
        private DataGridView? dgvWarehouse;
        private string UserLogin;
        public AcceptanceOfGoodsForm(string userLogin)
        {
            InitializeComponent();
            UserLogin = userLogin;
            labelLogin.Text = Resources.LoginInMenu + userLogin;
            CreateDataGridView();
            LoadProducts();
            comboBoxName.Click += comboBoxName_SelectedIndexChanged!;
            buttonAddToBusket.Click += buttonAddToBusket_Click!;
            buttonConfirm.Click += buttonConfirm_Click!;
            Logger.UserAction(UserLogin, "Открыта форма приёмки товаров");
        }
        private void CreateDataGridView()
        {
            dgvWarehouse = new DataGridView
            {
                Location = new Point(520, 90),
                Size = new Size(520, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10F),
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
            };
            Controls.Add(dgvWarehouse);
        }
        public void LoadProducts()
        {
            Logger.UserAction(UserLogin, "Загрузка списка товаров в DataGridView");
            using var db = new AllDB();
            var acceptance = db.ProductsOnAcceptance.Select(p => new
            {
                p.Name,
                p.Count,
                p.Price,
                p.ProviderName,
                p.LoginEmployee,
            }).ToList();
            if (dgvWarehouse != null)
            {
                dgvWarehouse.DataSource = acceptance;
                SetupColumns();
            }
        }
        private void SetupColumns()
        {
            if (dgvWarehouse == null) return;

            if (dgvWarehouse.Columns["Name"] != null)
                dgvWarehouse.Columns["Name"].HeaderText = "Название";
            if (dgvWarehouse.Columns["Count"] != null)
                dgvWarehouse.Columns["Count"].HeaderText = "Количество";
            if (dgvWarehouse.Columns["Price"] != null)
                dgvWarehouse.Columns["Price"].HeaderText = "Цена";
            if (dgvWarehouse.Columns["ProviderName"] != null)
                dgvWarehouse.Columns["ProviderName"].HeaderText = "Поставщик";
            if (dgvWarehouse.Columns["LoginEmployee"] != null)
                dgvWarehouse.Columns["LoginEmployee"].HeaderText = "Кто принял";
        }
        private void buttonAddToBusket_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Нажата кнопка добавления товара в корзину приёмки");

            using var db = new AllDB();

            if (comboBoxName.SelectedItem == null)
            {
                MessageBox.Show(Resources.EnterProductName);
                return;
            }
            if (!int.TryParse(numCount.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show(Resources.NumberCount);
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxProviderName.Text))
            {
                MessageBox.Show(Resources.EnterTheProvider);
                return;
            }
            if (!int.TryParse(numPrice.Text, out int price) || price <= 0)
            {
                MessageBox.Show(Resources.PurchasePrice);
                return;
            }
            var productOnAcceptance = new ProductsOnAcceptanceClass(
                comboBoxName.Text,
                (double)numCount.Value,
                numPrice.Value,
                comboBoxProviderName.Text,
                UserLogin
            );
            db.ProductsOnAcceptance.Add(productOnAcceptance);
            db.SaveChanges();
            Logger.UserAction(UserLogin, $"Товар '{comboBoxName.Text}' добавлен в корзину");
            LoadProducts();
            comboBoxName.SelectedItem = null;
            numCount.Value = 0;
            numPrice.Value = 0;
            comboBoxProviderName.Text = string.Empty;
        }
        private void comboBoxName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Загрузка списка товаров в комбобокс");
            comboBoxName.Items.Clear();
            using var db = new AllDB();
            foreach (var card in db.Products)
                comboBoxName.Items.Add(card.Name);
        }
        private void buttonCheckApi_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Открытие формы проверки контрагента по API");
            var checkForm = new SupplierCheckForm(UserLogin, this);
            checkForm.ShowDialog();
        }
        public void SetSupplierFromApi(string supplierName, string inn)
        {
            comboBoxProviderName.Text = supplierName;
            Logger.UserAction(UserLogin, $"Поставщик из API: {supplierName}, ИНН: {inn}");
        }
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Открытие формы подтверждения приёмки");

            using var db = new AllDB();
            if (!db.ProductsOnAcceptance.Any())
            {
                MessageBox.Show(Resources.BusketIsEmpty);
                return;
            }

            var confirmForm = new AcceptanceConfirmForm(UserLogin, this);
            confirmForm.ShowDialog();
        }
        public void ConfirmAcceptance()
        {
            using var db = new AllDB();
            int acceptedCount = 0;

            foreach (var product in db.ProductsOnAcceptance)
            {
                var existing = db.Products.FirstOrDefault(p => p.Name == product.Name);
                if (existing != null)
                {
                    existing.Rest += product.Count;
                    existing.PurchasePrice = product.Price;
                    acceptedCount++;
                }
            }
            db.SaveChanges();

            Logger.UserAction(UserLogin, $"Приёмка подтверждена. Принято позиций: {acceptedCount}");
            MessageBox.Show(Resources.Success);

            foreach (var product in db.ProductsOnAcceptance.ToList())
                db.ProductsOnAcceptance.Remove(product);
            db.SaveChanges();
            LoadProducts();
        }
        private void сменитьАккаунтToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Смена аккаунта из формы приёмки");
            var authForm = new Authorization();
            authForm.Show();
            Hide();
        }
        private void назадToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Возврат из формы приёмки");
            using var db = new AllDB();
            var emp = db.Employess.FirstOrDefault(e => e.Login == UserLogin);

            if (emp != null && emp.Job == JobsEnumcs.Administrator)
                new WarehouseAdmin(UserLogin).Show();
            else
                new WarehouseStorekeeper(UserLogin).Show();

            Close();
        }
        private async void buttonImport_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(UserLogin, "Импорт товаров из JSON");
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                string json = await File.ReadAllTextAsync(openFileDialog.FileName);
                var products = JsonConvert.DeserializeObject<List<ProductsOnAcceptanceClass>>(json);

                using var db = new AllDB();
                foreach (var p in products ?? new List<ProductsOnAcceptanceClass>())
                {
                    db.ProductsOnAcceptance.Add(new ProductsOnAcceptanceClass
                    {
                        Name = p.Name ?? string.Empty,
                        Count = p.Count,
                        Price = p.Price,
                        ProviderName = p.ProviderName ?? string.Empty,
                        LoginEmployee = UserLogin,
                    });
                }
                await db.SaveChangesAsync();

                Logger.UserAction(UserLogin, $"Импортировано {products?.Count ?? 0} товаров");
                MessageBox.Show($"{Resources.Import}: {products?.Count ?? 0} {Resources.Products}");
                LoadProducts();
            }
            catch (Exception ex)
            {
                Logger.UserAction(UserLogin, $"Ошибка импорта: {ex.Message}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}