using DiamonApp.Classes;
using DiamonApp.DataBase;
using DiamondApp.Hash;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Draft_Diamond_BD
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            enter.Click += enter_Click;
            btnRegister.Click += btnRegister_Click;
            Logger.UserAction("System", "Открыта форма авторизации");
        }

        private async void enter_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text.Trim();
            var password = SimpleHash.HashSHA256(txtPassword.Text.Trim());

            Logger.UserAction(login, $"Попытка входа в систему");

            await using var db = new AllDB();
            var user = db.Employess.FirstOrDefault(w => w.Login == login);

            if (user != null)
            {
                if (user.Password == password)
                {
                    Logger.UserAction(login, $"Успешный вход. Роль: {user.Job}");

                    if (user.Job == JobsEnumcs.Administrator)
                    {
                        var warehouseAdminForm = new WarehouseAdmin(user.Login);
                        warehouseAdminForm.Show();
                    }
                    else
                    {
                        var warehouseStorekeeperForm = new WarehouseStorekeeper(user.Login);
                        warehouseStorekeeperForm.Show();
                    }
                    Hide();
                }
                else
                {
                    Logger.UserAction(login, $"Ошибка: неверный пароль");
                    MessageBox.Show(Resources.ErrorPassword);
                }
            }
            else
            {
                Logger.UserAction(login, $"Ошибка: пользователь не найден");
                MessageBox.Show(Resources.ErrorLogin);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Logger.UserAction("System", "Переход на форму регистрации");
            var registerform = new Registration();
            registerform.Show();
            Hide();
        }
    }
}