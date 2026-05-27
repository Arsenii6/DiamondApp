namespace DiamonApp.forms
{
    /// <summary>
    /// Форма изменения названия категории
    /// </summary>
    public partial class ChangeCategory : Form
    {
        public string LoginAdmin;

        /// <summary>
        /// Инициализирует форму изменения категории
        /// </summary>
        public ChangeCategory(string loginAdmin)
        {
            InitializeComponent();
            comboBoxOldName.Click += comboBoxOldName_SelectedIndexChanged;
            buttonChangeCategory.Click += buttonChangeCategory_Click;
            LoginAdmin = loginAdmin;

            Logger.UserAction(LoginAdmin, "Открыта форма изменения категории");
        }

        /// <summary>
        /// Загружает список категорий в комбобокс
        /// </summary>
        private void comboBoxOldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка списка категорий в комбобокс");
            comboBoxOldName.Items.Clear();
            using (var db = new AllDB())
            {
                foreach (var item in db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory)
                {
                    comboBoxOldName.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение названия категории
        /// </summary>
        private void buttonChangeCategory_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка изменения категории");

            if (comboBoxOldName.SelectedItem == null)
            {
                Logger.UserAction(LoginAdmin, "Ошибка: не выбрана старая категория");
                MessageBox.Show(Resources.EnterCategoryName);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxNewName.Text))
            {
                Logger.UserAction(LoginAdmin, "Ошибка: не введено новое название категории");
                MessageBox.Show(Resources.EnterNewCategoryName);
                return;
            }

            string oldCategory = comboBoxOldName.SelectedItem.ToString();
            string newCategory = comboBoxNewName.Text.Trim();

            Logger.UserAction(LoginAdmin, $"Попытка изменить категорию '{oldCategory}' на '{newCategory}'");

            using (var db = new AllDB())
            {
                var categoryDb = db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory;
                var index = categoryDb.IndexOf(oldCategory);
                categoryDb[index] = newCategory;

                var products = db.Products.ToList();
                int updatedProductsCount = 0;
                foreach (var product in products)
                {
                    if (product.Category == oldCategory)
                    {
                        product.Category = newCategory;
                        updatedProductsCount++;
                    }
                }

                db.SaveChanges();

                Logger.UserAction(LoginAdmin, $"Категория '{oldCategory}' изменена на '{newCategory}'. Обновлено товаров: {updatedProductsCount}");

                MessageBox.Show($"{Resources.Success}");
                new WarehouseAdmin(LoginAdmin).Show();
                Close();
            }
        }

        /// <summary>
        /// Возврат на форму складского администратора
        /// </summary>
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы изменения категории");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}