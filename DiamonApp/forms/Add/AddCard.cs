namespace Draft_Diamond_BD
{
    /// <summary>
    /// Форма добавления новой карточки товара
    /// </summary>
    public partial class AddCard : Form
    {
        string LoginAdmin;

        /// <summary>
        /// Инициализирует форму добавления карточки товара
        /// </summary>
        public AddCard(string loginAdmin)
        {
            InitializeComponent();
            comboBoxUniteOfMeasure.Click += comboBoxUniteOfMeasure_SelectedIndexChanged;
            comboBoxCategory.Click += comboBoxCategory_SelectedIndexChanged;
            LoginAdmin = loginAdmin;

            Logger.UserAction(LoginAdmin, "Открыта форма добавления карточки товара");
        }

        /// <summary>
        /// Загружает единицы измерения при выборе комбобокса
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
        /// Обрабатывает добавление нового товара в базу данных
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка добавления товара");

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                Logger.UserAction(LoginAdmin, "Ошибка: пустое поле названия товара");
                MessageBox.Show(Resources.EnterProductName);
                return;
            }

            if (comboBoxUniteOfMeasure.SelectedItem == null)
            {
                Logger.UserAction(LoginAdmin, "Ошибка: не выбрана единица измерения");
                MessageBox.Show(Resources.ChoseUniteOfMeasure);
                return;
            }

            Logger.UserAction(LoginAdmin, $"Попытка добавить товар: Название='{textBoxName.Text.Trim()}', Ед.изм='{comboBoxUniteOfMeasure.SelectedItem}', Категория='{comboBoxCategory.Text}'");

            using (var db = new AllDB())
            {
                var newProduct = new ProductClass(
                    textBoxName.Text.Trim(),
                    (string)comboBoxUniteOfMeasure.SelectedItem,
                    0,
                    comboBoxCategory.Text,
                    0,
                    LoginAdmin,
                    DateTime.Today,
                    0,
                    0,
                    0,
                    true
                );

                db.Products.Add(newProduct);
                db.SaveChanges();

                Logger.UserAction(LoginAdmin, $"Товар успешно добавлен: '{textBoxName.Text.Trim()}'");

                MessageBox.Show(Resources.AddProduct);
                textBoxName.Clear();
                comboBoxUniteOfMeasure.SelectedItem = null;
                Close();
                var newWarehouseAdmin = new WarehouseAdmin(LoginAdmin);
                newWarehouseAdmin.Show();
            }
        }

        /// <summary>
        /// Загружает категории при выборе комбобокса
        /// </summary>
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка категорий в комбобокс");
            comboBoxCategory.Items.Clear();
            using (var db = new AllDB())
            {
                foreach (var category in db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory)
                {
                    comboBoxCategory.Items.Add(category);
                }
            }
        }

        /// <summary>
        /// Возврат на главную форму складского администратора
        /// </summary>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}