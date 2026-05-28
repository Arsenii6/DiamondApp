namespace DiamonApp.forms
{
    public partial class DeleteCard : Form
    {
        public string LoginAdmin;
        public DeleteCard(string loginAdmin)
        {
            InitializeComponent();
            LoginAdmin = loginAdmin;
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;
            Logger.UserAction(LoginAdmin, "Открыта форма удаления карточки товара");
        }
        private void comboBoxName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка списка товаров в комбобокс");
            comboBoxName.Items.Clear();
            using var db = new AllDB();
            foreach (var name in db.Products)
                comboBoxName.Items.Add(name.Name);
        }
        private async void buttonDeleteCategory_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка удаления товара");
            await using var db = new AllDB();
            if (comboBoxName.SelectedIndex == -1 || comboBoxName.SelectedItem == null)
            {
                Logger.UserAction(LoginAdmin, "Ошибка: не выбран товар для удаления");
                MessageBox.Show(Resources.EnterTheCard);
                return;
            }
            string productNameToDelete = comboBoxName.SelectedItem.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(productNameToDelete))
            {
                Logger.UserAction(LoginAdmin, "Ошибка: название товара пусто");
                MessageBox.Show(Resources.EnterTheCard);
                return;
            }
            var product = db.Products.FirstOrDefault(p => p.Name == productNameToDelete);
            if (product != null)
            {
                Logger.UserAction(LoginAdmin, $"Попытка удалить товар: '{product.Name}' (Id: {product.Id})");
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                Logger.UserAction(LoginAdmin, $"Товар '{product.Name}' успешно удалён из базы данных");
                MessageBox.Show($"{Resources.Success}");
                new WarehouseAdmin(LoginAdmin).Show();
                Close();
            }
            else
            {
                Logger.UserAction(LoginAdmin, $"Ошибка: товар '{productNameToDelete}' не найден");
                MessageBox.Show(Resources.NotDatabase);
            }
        }
        private void BackToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы удаления карточки");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}