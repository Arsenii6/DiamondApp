namespace DiamonApp.forms
{
    /// <summary>
    /// Форма удаления карточки товара
    /// </summary>
    public partial class DeleteCard : Form
    {
        public string LoginAdmin;

        /// <summary>
        /// Инициализирует форму удаления карточки товара
        /// </summary>
        public DeleteCard(string loginAdmin)
        {
            InitializeComponent();
            LoginAdmin = loginAdmin;
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;

            Logger.UserAction(LoginAdmin, "Открыта форма удаления карточки товара");
        }

        /// <summary>
        /// Обрабатывает удаление товара из базы данных
        /// </summary>
        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Нажата кнопка удаления товара");

            using (var db = new AllDB())
            {
                if (comboBoxName.SelectedIndex == 0)
                {
                    Logger.UserAction(LoginAdmin, "Ошибка: не выбран товар для удаления");
                    MessageBox.Show(Resources.EnterTheCard);
                    return;
                }

                var id = new Guid();
                string productNameToDelete = "";
                foreach (var name in db.Products.ToList())
                {
                    if (name.Name == comboBoxName.Text)
                    {
                        id = name.Id;
                        productNameToDelete = name.Name;
                        break;
                    }
                }

                Logger.UserAction(LoginAdmin, $"Попытка удалить товар: '{productNameToDelete}' (Id: {id})");

                var card = db.Products.FirstOrDefault(p => p.Id == id);
                db.Products.Remove(card);
                db.SaveChanges();

                Logger.UserAction(LoginAdmin, $"Товар '{productNameToDelete}' успешно удалён из базы данных");

                MessageBox.Show($"{Resources.Success}");
                new WarehouseAdmin(LoginAdmin).Show();
                Close();
            }
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
        /// Возврат на форму складского администратора
        /// </summary>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(LoginAdmin, "Возврат на форму WarehouseAdmin из формы удаления карточки");
            new WarehouseAdmin(LoginAdmin).Show();
            Hide();
        }
    }
}