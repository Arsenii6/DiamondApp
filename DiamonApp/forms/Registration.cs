namespace DiamonApp
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            buttonRegister.Click += btnCreate_Click;
            btnAuthorization.Click += btnAuthorization_Click;
            Logger.UserAction("System", "Открыта форма регистрации");
        }
        private async void btnCreate_Click(object sender, EventArgs e)
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
            await using var db = new AllDB();
            var existingUser = db.Employess.FirstOrDefault(w => w.Login == login);
            if (existingUser != null)
            {
                Logger.UserAction(login, "Ошибка регистрации: такой логин уже существует");
                MessageBox.Show(Resources.SuchLogin);
                return;
            }
            var newWorker = new EmployeeClass(name, surname, login,
                SimpleHash.HashSHA256(password), JobsEnumcs.Storekeeper);
            await db.Employess.AddAsync(newWorker);
            await db.SaveChangesAsync();
            Logger.UserAction(login, $"Пользователь {login} успешно зарегистрирован");
            MessageBox.Show(Resources.Success);
            var authForm = new Authorization();
            authForm.Show();
            Hide();
        }
        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            Logger.UserAction("System", "Переход на форму авторизации из формы регистрации");
            new Authorization().Show();
            Hide();
        }
    }
}