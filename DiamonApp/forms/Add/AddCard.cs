namespace Draft_Diamond_BD
{
    public partial class AddCard : Form
    {
        string LoginAdmin;
        public AddCard(string loginAdmin)
        {
            InitializeComponent();
            LoginAdmin = loginAdmin;
            Logger.UserAction(LoginAdmin, "Открыта форма добавления карточки товара");
        }
        private void comboBoxUniteOfMeasure_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка единиц измерения в комбобокс");
            comboBoxUniteOfMeasure.Items.Clear();
            using var db = new AllDB();
            var units = db.UniteOfMeasures.FirstOrDefault(p => p.Id == 1);
            if (units != null)
            {
                foreach (var unite in units.UnitesOfMeasure)
                    comboBoxUniteOfMeasure.Items.Add(unite);
            }
        }
        private async void buttonAdd_Click(object sender, EventArgs e)
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

            await using var db = new AllDB();
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
            await db.Products.AddAsync(newProduct);
            await db.SaveChangesAsync();

            Logger.UserAction(LoginAdmin, $"Товар успешно добавлен: '{textBoxName.Text.Trim()}'");

            MessageBox.Show(Resources.AddProduct);
            textBoxName.Clear();
            comboBoxUniteOfMeasure.SelectedItem = null;
            Close();
        }
        private void comboBoxCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Загрузка категорий в комбобокс");
            comboBoxCategory.Items.Clear();
            using var db = new AllDB();
            var categories = db.Categories.FirstOrDefault(p => p.Id == 1);
            if (categories != null)
            {
                foreach (var category in categories.NamesOfCategory)
                    comboBoxCategory.Items.Add(category);
            }
        }
        private void BackToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin");
            Close();
        }
    }
}