namespace Draft_Diamond_BD
{
    /// <summary>
    /// Форма изменения карточки товара
    /// </summary>
    public partial class ChangeCard : Form
    {
        public string LoginAdmin;

        /// <summary>
        /// Инициализирует форму изменения карточки товара
        /// </summary>
        public ChangeCard(string loginAdmin)
        {
            InitializeComponent();
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            comboBoxUniteOfMeasure.Click += comboBoxUniteOfMeasure_SelectedIndexChanged;
            buttonChange.Click += buttonChange_Click;
            LoginAdmin = loginAdmin;

            Logger.UserAction(LoginAdmin, "Открыта форма изменения карточки товара");
        }

        /// <summary>
        /// Загружает список товаров в комбобокс
        /// </summary>
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка списка товаров в комбобокс");
            comboBoxName.Items.Clear();
            using (var db = new AllDB())
            {
                foreach (var name in db.Products)
                {
                    comboBoxName.Items.Add(name.Name);
                }
            }
        }

        /// <summary>
        /// Загружает единицы измерения в комбобокс
        /// </summary>
        private void comboBoxUniteOfMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка единиц измерения в комбобокс");
            comboBoxUniteOfMeasure.Items.Clear();
            using (var db = new AllDB())
            {
                foreach (var unite in db.UniteOfMeasures.FirstOrDefault(p => p.Id == 1).UnitesOfMeasure)
                {
                    comboBoxUniteOfMeasure.Items.Add(unite);
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение цены и единицы измерения товара
        /// </summary>
        private void buttonChange_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, $"Нажата кнопка изменения товара. Выбранный товар: '{comboBoxName.Text}'");

            using (var db = new AllDB())
            {
                var product = db.Products.FirstOrDefault(p => p.Name == comboBoxName.Text);

                if (product != null)
                {
                    var oldPrice = product.PurchasePrice;
                    var oldUnit = product.UniteOfMeasure;

                    product.PurchasePrice = Convert.ToDecimal(numePurchasePrise.Text);

                    if (comboBoxUniteOfMeasure.SelectedItem != null)
                    {
                        product.UniteOfMeasure = (string)comboBoxUniteOfMeasure.SelectedItem;
                    }

                    db.SaveChanges();

                    Logger.UserAction(LoginAdmin, $"Товар изменён: '{product.Name}' | Цена: {oldPrice} -> {product.PurchasePrice} | Ед.изм: {oldUnit} -> {product.UniteOfMeasure}");

                    MessageBox.Show($"{Resources.Success}");
                    new WarehouseAdmin(LoginAdmin).Show();
                    Close();
                }
                else
                {
                    Logger.UserAction(LoginAdmin, $"Ошибка: товар '{comboBoxName.Text}' не найден в базе данных");
                    MessageBox.Show(Resources.NotDatabase);
                }
            }
        }

        /// <summary>
        /// Возврат на форму складского администратора
        /// </summary>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы изменения карточки");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}