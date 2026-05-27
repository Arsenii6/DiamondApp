namespace Draft_Diamond_BD
{
    /// <summary>
    /// Форма склада списанных (просроченных) товаров
    /// </summary>
    public partial class WrittenOffForm : Form
    {
        private DataGridView dgvWrittenOff;
        private readonly string _userLogin;

        public WrittenOffForm(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;
            CreateDataGridView();
            LoadWrittenOff();
            Logger.UserAction(_userLogin, "Открыта форма списанных товаров");
        }

        private void CreateDataGridView()
        {
            dgvWrittenOff = new DataGridView
            {
                Location = new System.Drawing.Point(30, 95),
                Size = new System.Drawing.Size(840, 590),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Font = new System.Drawing.Font("Segoe UI", 10F),
            };
            Controls.Add(dgvWrittenOff);
        }

        private void LoadWrittenOff()
        {
            Logger.UserAction(_userLogin, "Загрузка списанных товаров");
            using (var db = new AllDB())
            {
                var productsFalse = db.Products.Where(p => p.Status == false).ToList();

                var data = productsFalse.Select(p => new
                {
                    Название = p.Name,
                    Единица_измерения = p.UniteOfMeasure,
                    Цена_закупки = AppCurrencyManager.Format(p.PurchasePrice),
                    Текущий_остаток = p.Rest,
                    Сезон_до = p.EndDateOfTheDay,
                    Убыток = AppCurrencyManager.Format(p.FinalyPrice),
                }).ToList();

                dgvWrittenOff.DataSource = data;

                // Убираем подчёркивания из заголовков
                foreach (DataGridViewColumn col in dgvWrittenOff.Columns)
                    col.HeaderText = col.HeaderText.Replace("_", " ");

                decimal totalSum = productsFalse.Sum(p => p.PurchasePrice);
                decimal totalLoss = productsFalse.Sum(p => p.FinalyPrice);
                int count = productsFalse.Count;

                labelTotalValue.Text = AppCurrencyManager.Format(totalSum);
                labelCountValue.Text = count.ToString();
                labelLossValue.Text = AppCurrencyManager.Format(totalLoss);

                Logger.UserAction(_userLogin, $"Списанных товаров: {count}, убыток: {AppCurrencyManager.Format(totalLoss)}");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Возврат на форму администратора");
            new WarehouseAdmin(_userLogin).Show();
            Hide();
        }

    }
}