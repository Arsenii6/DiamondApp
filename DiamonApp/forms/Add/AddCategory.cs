namespace DiamonApp.forms
{
    /// <summary>
    /// Форма добавления новой категории товаров
    /// </summary>
    public partial class AddCategory : Form
    {
        public string LoginAdmin;

        /// <summary>
        /// Инициализирует форму добавления категории
        /// </summary>
        public AddCategory(string loginAdmin)
        {
            InitializeComponent();
            buttonAdd.Click += buttonAddCategory_Click;
            LoginAdmin = loginAdmin;

            Logger.UserAction(LoginAdmin, "Открыта форма добавления категории");
        }

        /// <summary>
        /// Обрабатывает добавление новой категории в базу данных
        /// </summary>
        private void buttonAddCategory_Click(object sender, EventArgs e)
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

            using (var db = new AllDB())
            {
                var flag = false;
                foreach (var category in db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory)
                {
                    if (newCategory == category.ToLower())
                    {
                        flag = true; break;
                    }
                }
                if (flag)
                {
                    Logger.UserAction(LoginAdmin, $"Ошибка: категория '{textBoxName.Text.Trim()}' уже существует");
                    MessageBox.Show(Resources.CategoryIsExisting);
                    return;
                }

                db.Categories.FirstOrDefault(p => p.Id == 1).NamesOfCategory.Add(textBoxName.Text.Trim());
                Logger.UserAction(LoginAdmin, $"Категория '{textBoxName.Text.Trim()}' успешно добавлена");

                MessageBox.Show(Resources.Success);
                new WarehouseAdmin(LoginAdmin).Show();
                db.SaveChanges();
                Close();
            }
        }

        /// <summary>
        /// Возврат на главную форму складского администратора
        /// </summary>
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы добавления категории");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}