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
            labelTitle = new Label();
            labelName = new Label();
            labelSurname = new Label();
            labelLogin = new Label();
            labelPassword = new Label();
            textBoxName = new TextBox();
            textBoxSurname = new TextBox();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonRegister = new Button();
            btnAuthorization = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(75, 35);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(268, 54);
            labelTitle.TabIndex = 10;
            labelTitle.Text = "Регистрация";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 11F);
            labelName.Location = new Point(50, 95);
            labelName.Name = "labelName";
            labelName.Size = new Size(60, 30);
            labelName.TabIndex = 9;
            labelName.Text = "Имя:";
            // 
            // labelSurname
            // 
            labelSurname.AutoSize = true;
            labelSurname.Font = new Font("Segoe UI", 11F);
            labelSurname.Location = new Point(50, 168);
            labelSurname.Name = "labelSurname";
            labelSurname.Size = new Size(109, 30);
            labelSurname.TabIndex = 7;
            labelSurname.Text = "Фамилия:";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 11F);
            labelLogin.Location = new Point(50, 238);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(80, 30);
            labelLogin.TabIndex = 5;
            labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 11F);
            labelPassword.Location = new Point(50, 308);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(94, 30);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Пароль:";
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 11F);
            textBoxName.Location = new Point(50, 128);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(300, 37);
            textBoxName.TabIndex = 8;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Font = new Font("Segoe UI", 11F);
            textBoxSurname.Location = new Point(50, 198);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(300, 37);
            textBoxSurname.TabIndex = 6;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI", 11F);
            textBoxLogin.Location = new Point(50, 268);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(300, 37);
            textBoxLogin.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(50, 338);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(300, 37);
            textBoxPassword.TabIndex = 2;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.SteelBlue;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.Location = new Point(50, 395);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(300, 42);
            buttonRegister.TabIndex = 1;
            buttonRegister.Text = "Зарегистрироваться";
            buttonRegister.UseVisualStyleBackColor = false;
            // 
            // btnAuthorization
            // 
            btnAuthorization.BackColor = Color.White;
            btnAuthorization.FlatAppearance.BorderColor = Color.SteelBlue;
            btnAuthorization.FlatStyle = FlatStyle.Flat;
            btnAuthorization.Font = new Font("Segoe UI", 11F);
            btnAuthorization.ForeColor = Color.SteelBlue;
            btnAuthorization.Location = new Point(50, 452);
            btnAuthorization.Name = "btnAuthorization";
            btnAuthorization.Size = new Size(300, 38);
            btnAuthorization.TabIndex = 0;
            btnAuthorization.Text = "← Назад к входу";
            btnAuthorization.UseVisualStyleBackColor = false;
            // 
            // Registration
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(400, 520);
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