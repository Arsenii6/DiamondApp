namespace DiamonApp.forms
{
    public partial class AddCategory : Form
    {
        public string LoginAdmin;
        public AddCategory(string loginAdmin)
        {
            InitializeComponent();
            buttonAdd.Click += buttonAddCategory_Click;
            LoginAdmin = loginAdmin;
            Logger.UserAction(LoginAdmin, "Открыта форма добавления категории");
        }
        private async void buttonAddCategory_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка добавления категории");

            var newCategory = textBoxName.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                Logger.UserAction(LoginAdmin, "Ошибка: пустое поле названия категории");
                MessageBox.Show(Resources.EnterCategoryName);
                return;
            }
            Logger.UserAction(LoginAdmin, $"Попытка добавить категорию: '{textBoxName.Text.Trim()}'");
            await using var db = new AllDB();
            var categoryList = db.Categories.FirstOrDefault(p => p.Id == 1);

            if (categoryList != null)
            {
                var flag = false;
                foreach (var category in categoryList.NamesOfCategory)
                {
                    if (newCategory == category.ToLower())
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    Logger.UserAction(LoginAdmin, $"Ошибка: категория '{textBoxName.Text.Trim()}' уже существует");
                    MessageBox.Show(Resources.CategoryIsExisting);
                    return;
                }
                categoryList.NamesOfCategory.Add(textBoxName.Text.Trim());
                await db.SaveChangesAsync();
                Logger.UserAction(LoginAdmin, $"Категория '{textBoxName.Text.Trim()}' успешно добавлена");
                MessageBox.Show(Resources.Success);
                new WarehouseAdmin(LoginAdmin).Show();
                Close();
            }
        }
        private void backToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы добавления категории");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}