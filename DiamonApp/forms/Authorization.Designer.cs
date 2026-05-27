namespace Draft_Diamond_BD
{
    partial class Authorization
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelTitle = new System.Windows.Forms.Label();
            labelLogin = new System.Windows.Forms.Label();
            labelPassword = new System.Windows.Forms.Label();
            txtLogin = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            enter = new System.Windows.Forms.Button();
            btnRegister = new System.Windows.Forms.Button();
            SuspendLayout();

            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(95, 40);
            labelTitle.Text = "Вход в систему";

            labelLogin.AutoSize = true;
            labelLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelLogin.Location = new System.Drawing.Point(60, 120);
            labelLogin.Text = "Логин:";

            txtLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtLogin.Location = new System.Drawing.Point(60, 148);
            txtLogin.Size = new System.Drawing.Size(300, 32);
            txtLogin.Name = "txtLogin";

            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelPassword.Location = new System.Drawing.Point(60, 200);
            labelPassword.Text = "Пароль:";

            txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtPassword.Location = new System.Drawing.Point(60, 228);
            txtPassword.Size = new System.Drawing.Size(300, 32);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';

            enter.BackColor = System.Drawing.Color.SteelBlue;
            enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            enter.FlatAppearance.BorderSize = 0;
            enter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            enter.ForeColor = System.Drawing.Color.White;
            enter.Location = new System.Drawing.Point(60, 290);
            enter.Size = new System.Drawing.Size(300, 42);
            enter.Text = "Войти";
            enter.Name = "enter";

            btnRegister.BackColor = System.Drawing.Color.White;
            btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnRegister.ForeColor = System.Drawing.Color.SteelBlue;
            btnRegister.Location = new System.Drawing.Point(60, 348);
            btnRegister.Size = new System.Drawing.Size(300, 38);
            btnRegister.Text = "Регистрация";
            btnRegister.Name = "btnRegister";

            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(420, 430);
            Controls.Add(btnRegister);
            Controls.Add(enter);
            Controls.Add(txtPassword);
            Controls.Add(labelPassword);
            Controls.Add(txtLogin);
            Controls.Add(labelLogin);
            Controls.Add(labelTitle);
            Name = "Authorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}