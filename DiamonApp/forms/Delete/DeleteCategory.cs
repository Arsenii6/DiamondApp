namespace DiamonApp.forms
{
    public partial class DeleteCategory : Form
    {
        public string LoginAdmin;
        public DeleteCategory(string loginAdmin)
        {
            InitializeComponent();
            LoginAdmin = loginAdmin;
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;
            Logger.UserAction(LoginAdmin, "Открыта форма удаления категории");
        }
        private void comboBoxName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка списка категорий в комбобокс");
            comboBoxName.Items.Clear();
            using var db = new AllDB();
            var categories = db.Categories.FirstOrDefault(p => p.Id == 1);
            if (categories?.NamesOfCategory != null)
            {
                foreach (var name in categories.NamesOfCategory)
                    comboBoxName.Items.Add(name);
            }
        }
        private async void buttonDeleteCategory_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка удаления категории");

            await using var db = new AllDB();

            if (comboBoxName.SelectedIndex == -1 || comboBoxName.SelectedItem == null)
            {
                Logger.UserAction(LoginAdmin, "Ошибка: не выбрана категория для удаления");
                MessageBox.Show(Resources.EnterTheCategory);
                return;
            }
            string categoryToDelete = comboBoxName.SelectedItem.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(categoryToDelete))
            {
                Logger.UserAction(LoginAdmin, "Ошибка: название категории пусто");
                MessageBox.Show(Resources.EnterTheCategory);
                return;
            }
            Logger.UserAction(LoginAdmin, $"Попытка удалить категорию: '{categoryToDelete}'");
            int deletedProductsCount = 0;
            var productsToDelete = db.Products.Where(p => p.Category == categoryToDelete).ToList();
            foreach (var product in productsToDelete)
            {
                db.Products.Remove(product);
                deletedProductsCount++;
            }
            Logger.UserAction(LoginAdmin, $"Удалено товаров с категорией '{categoryToDelete}': {deletedProductsCount}");

            var categoryDb = db.Categories.FirstOrDefault(p => p.Id == 1);
            if (categoryDb?.NamesOfCategory != null)
                categoryDb.NamesOfCategory.Remove(categoryToDelete);

            await db.SaveChangesAsync();

            Logger.UserAction(LoginAdmin, $"Категория '{categoryToDelete}' успешно удалена из базы данных");

            MessageBox.Show($"{Resources.Success}");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
        private void BackToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы удаления категории");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}