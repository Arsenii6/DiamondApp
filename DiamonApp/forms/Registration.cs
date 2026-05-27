namespace DiamonApp
{
    /// <summary>
    /// Форма регистрации новых пользователей
    /// </summary>
    public partial class Registration : Form
    {
        /// <summary>
        /// Инициализирует форму регистрации
        /// </summary>
        public Registration()
        {
            InitializeComponent();
            buttonRegister.Click += btnCreate_Click;
            btnAuthorization.Click += btnAuthorization_Click;

            Logger.UserAction("System", "Открыта форма регистрации");
        }

        /// <summary>
        /// Обрабатывает создание нового пользователя
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text.Trim();
            var password = textBoxPassword.Text.Trim();
            var name = textBoxName.Text.Trim();
            var surname = textBoxSurname.Text.Trim();

            Logger.UserAction(login, $"Попытка регистрации нового пользователя: {name} {surname}");

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                Logger.UserAction(login, "Ошибка регистрации: не все поля заполнены");
                MessageBox.Show(Resources.EnterTheCorrectInformation);
                return;
            }
            using (var db = new AllDB())
            {
                var existingUser = db.Employess.FirstOrDefault(w => w.Login == login);
                if (existingUser != null)
                {
                    Logger.UserAction(login, "Ошибка регистрации: такой логин уже существует");
                    MessageBox.Show(Resources.SuchLogin);
                    return;
                }
                var newWorker = new EmployeeClass(name, surname, login, SimpleHash.HashSHA256(password), JobsEnumcs.Storekeeper);

                db.Employess.Add(newWorker);
                db.SaveChanges();
            }

            Logger.UserAction(login, $"Пользователь {login} успешно зарегистрирован");
            MessageBox.Show(Resources.Success);
            new Authorization().Show();
            Hide();
        }

        /// <summary>
        /// Переход на форму авторизации
        /// </summary>
        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            Logger.UserAction("System", "Переход на форму авторизации из формы регистрации");
            new Authorization().Show();
            Hide();
        }
    }
}