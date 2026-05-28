namespace DiamonApp.forms
{
    public partial class ChangeCategory : Form
    {
        public string LoginAdmin;
        public ChangeCategory(string loginAdmin)
        {
            InitializeComponent();
            comboBoxOldName.Click += comboBoxOldName_SelectedIndexChanged;
            buttonChangeCategory.Click += buttonChangeCategory_Click;
            LoginAdmin = loginAdmin;
            Logger.UserAction(LoginAdmin, "Открыта форма изменения категории");
        }
        private void comboBoxOldName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка списка категорий в комбобокс");
            comboBoxOldName.Items.Clear();
            using var db = new AllDB();
            var categories = db.Categories.FirstOrDefault(p => p.Id == 1);
            if (categories?.NamesOfCategory != null)
            {
                foreach (var item in categories.NamesOfCategory)
                    comboBoxOldName.Items.Add(item);
            }
        }
        private async void buttonChangeCategory_Click(object? sender, EventArgs e)
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
            string oldCategory = comboBoxOldName.SelectedItem.ToString() ?? string.Empty;
            string newCategory = comboBoxNewName.Text.Trim();

            if (string.IsNullOrEmpty(oldCategory))
            {
                Logger.UserAction(LoginAdmin, "Ошибка: старая категория пуста");
                MessageBox.Show(Resources.EnterCategoryName);
                return;
            }

            Logger.UserAction(LoginAdmin, $"Попытка изменить категорию '{oldCategory}' на '{newCategory}'");

            await using var db = new AllDB();
            var categoryDb = db.Categories.FirstOrDefault(p => p.Id == 1);

            if (categoryDb?.NamesOfCategory != null)
            {
                int index = -1;
                for (int i = 0; i < categoryDb.NamesOfCategory.Count; i++)
                {
                    if (categoryDb.NamesOfCategory[i] == oldCategory)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                    categoryDb.NamesOfCategory[index] = newCategory;

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
                await db.SaveChangesAsync();
                Logger.UserAction(LoginAdmin, $"Категория '{oldCategory}' изменена на '{newCategory}'. Обновлено товаров: {updatedProductsCount}");
                MessageBox.Show($"{Resources.Success}");
                new WarehouseAdmin(LoginAdmin).Show();
                Close();
            }
        }
        private void backToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы изменения категории");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}