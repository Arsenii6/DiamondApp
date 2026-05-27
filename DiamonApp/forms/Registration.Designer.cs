namespace DiamonApp
{
    partial class Registration
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button btnAuthorization;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelTitle = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();
            labelSurname = new System.Windows.Forms.Label();
            labelLogin = new System.Windows.Forms.Label();
            labelPassword = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            textBoxSurname = new System.Windows.Forms.TextBox();
            textBoxLogin = new System.Windows.Forms.TextBox();
            textBoxPassword = new System.Windows.Forms.TextBox();
            buttonRegister = new System.Windows.Forms.Button();
            btnAuthorization = new System.Windows.Forms.Button();
            SuspendLayout();

            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(75, 35);
            labelTitle.Text = "Регистрация";

            // Имя
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelName.Location = new System.Drawing.Point(50, 105);
            labelName.Text = "Имя:";
            textBoxName.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBoxName.Location = new System.Drawing.Point(50, 128);
            textBoxName.Size = new System.Drawing.Size(300, 30);
            textBoxName.Name = "textBoxName";

            // Фамилия
            labelSurname.AutoSize = true;
            labelSurname.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelSurname.Location = new System.Drawing.Point(50, 175);
            labelSurname.Text = "Фамилия:";
            textBoxSurname.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBoxSurname.Location = new System.Drawing.Point(50, 198);
            textBoxSurname.Size = new System.Drawing.Size(300, 30);
            textBoxSurname.Name = "textBoxSurname";

            // Логин
            labelLogin.AutoSize = true;
            labelLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelLogin.Location = new System.Drawing.Point(50, 245);
            labelLogin.Text = "Логин:";
            textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBoxLogin.Location = new System.Drawing.Point(50, 268);
            textBoxLogin.Size = new System.Drawing.Size(300, 30);
            textBoxLogin.Name = "textBoxLogin";

            // Пароль
            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelPassword.Location = new System.Drawing.Point(50, 315);
            labelPassword.Text = "Пароль:";
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBoxPassword.Location = new System.Drawing.Point(50, 338);
            textBoxPassword.Size = new System.Drawing.Size(300, 30);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';

            // Кнопка Зарегистрировать
            buttonRegister.BackColor = System.Drawing.Color.SteelBlue;
            buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            buttonRegister.ForeColor = System.Drawing.Color.White;
            buttonRegister.Location = new System.Drawing.Point(50, 395);
            buttonRegister.Size = new System.Drawing.Size(300, 42);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Text = "Зарегистрироваться";

            // Кнопка назад к авторизации
            btnAuthorization.BackColor = System.Drawing.Color.White;
            btnAuthorization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAuthorization.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            btnAuthorization.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnAuthorization.ForeColor = System.Drawing.Color.SteelBlue;
            btnAuthorization.Location = new System.Drawing.Point(50, 452);
            btnAuthorization.Size = new System.Drawing.Size(300, 38);
            btnAuthorization.Name = "btnAuthorization";
            btnAuthorization.Text = "← Назад к входу";

            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(400, 520);
            Controls.Add(btnAuthorization);
            Controls.Add(buttonRegister);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(labelLogin);
            Controls.Add(textBoxSurname);
            Controls.Add(labelSurname);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(labelTitle);
            Name = "Registration";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}