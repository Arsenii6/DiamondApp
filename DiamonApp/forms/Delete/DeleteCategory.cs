namespace DiamonApp.forms
{
    /// <summary>
    /// Форма удаления категории товаров
    /// </summary>
    public partial class DeleteCategory : Form
    {
        public string LoginAdmin;

        /// <summary>
        /// Инициализирует форму удаления категории
        /// </summary>
        public DeleteCategory(string loginAdmin)
        {
            InitializeComponent();
            LoginAdmin = loginAdmin;
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;

            Logger.UserAction(LoginAdmin, "Открыта форма удаления категории");
        }

        /// <summary>
        /// Загружает список категорий в комбобокс
        /// </summary>
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка списка категорий в комбобокс");
            comboBoxName.Items.Clear();
            using (var db = new AllDB())
            {
                foreach (var name in db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory)
                {
                    comboBoxName.Items.Add(name);
                }
            }
        }

        /// <summary>
        /// Обрабатывает удаление категории и всех товаров в ней
        /// </summary>
        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка удаления категории");

            using (var db = new AllDB())
            {
                if (comboBoxName.SelectedIndex == 0)
                {
                    Logger.UserAction(LoginAdmin, "Ошибка: не выбрана категория для удаления");
                    MessageBox.Show(Resources.EnterTheCategory);
                    return;
                }

                string categoryToDelete = comboBoxName.Text;
                Logger.UserAction(LoginAdmin, $"Попытка удалить категорию: '{categoryToDelete}'");

                int deletedProductsCount = 0;
                foreach (var name in db.Products)
                {
                    if (name.Category == comboBoxName.Text)
                    {
                        var product = name;
                        db.Products.Remove(product);
                        deletedProductsCount++;
                    }
                }

                Logger.UserAction(LoginAdmin, $"Удалено товаров с категорией '{categoryToDelete}': {deletedProductsCount}");

                db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory.Remove(comboBoxName.Text);
                db.SaveChanges();

                Logger.UserAction(LoginAdmin, $"Категория '{categoryToDelete}' успешно удалена из базы данных");

                MessageBox.Show($"{Resources.Success}");
                new WarehouseAdmin(LoginAdmin).Show();
                Hide();
            }
        }

        /// <summary>
        /// Возврат на форму складского администратора
        /// </summary>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы удаления категории");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}