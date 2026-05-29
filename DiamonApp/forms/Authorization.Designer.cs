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
            labelTitle = new Label();
            labelLogin = new Label();
            labelPassword = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            enter = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(60, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(320, 54);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Вход в систему";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 12F);
            labelLogin.Location = new Point(60, 113);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(86, 32);
            labelLogin.TabIndex = 5;
            labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 12F);
            labelPassword.Location = new Point(60, 193);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(101, 32);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Пароль:";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI", 12F);
            txtLogin.Location = new Point(60, 148);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(300, 39);
            txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(60, 228);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 39);
            txtPassword.TabIndex = 2;
            // 
            // enter
            // 
            enter.BackColor = Color.SteelBlue;
            enter.FlatAppearance.BorderSize = 0;
            enter.FlatStyle = FlatStyle.Flat;
            enter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            enter.ForeColor = Color.White;
            enter.Location = new Point(60, 290);
            enter.Name = "enter";
            enter.Size = new Size(300, 42);
            enter.TabIndex = 1;
            enter.Text = "Войти";
            enter.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.White;
            btnRegister.FlatAppearance.BorderColor = Color.SteelBlue;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F);
            btnRegister.ForeColor = Color.SteelBlue;
            btnRegister.Location = new Point(60, 348);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(300, 38);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // Authorization
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(420, 430);
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