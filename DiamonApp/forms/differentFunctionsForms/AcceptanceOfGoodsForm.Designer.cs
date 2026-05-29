namespace DiamondApp.forms.differentFunctionsForms
{
    partial class AcceptanceOfGoodsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьАккаунтToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label labelProvider;
        private System.Windows.Forms.ComboBox comboBoxProviderName;
        private System.Windows.Forms.Button buttonCheckApi;
        private System.Windows.Forms.Button buttonAddToBusket;
        private System.Windows.Forms.Label labelBusket;
        private System.Windows.Forms.Label labelImport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonConfirm;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            назадToolStripMenuItem = new ToolStripMenuItem();
            сменитьАккаунтToolStripMenuItem = new ToolStripMenuItem();
            labelTitle = new Label();
            labelLogin = new Label();
            labelName = new Label();
            comboBoxName = new ComboBox();
            labelCount = new Label();
            numCount = new NumericUpDown();
            labelPrice = new Label();
            numPrice = new NumericUpDown();
            labelProvider = new Label();
            comboBoxProviderName = new ComboBox();
            buttonCheckApi = new Button();
            buttonAddToBusket = new Button();
            labelBusket = new Label();
            labelImport = new Label();
            buttonImport = new Button();
            buttonConfirm = new Button();
            menuStrip1.SuspendLayout();
            ((ISupportInitialize)numCount).BeginInit();
            ((ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { назадToolStripMenuItem, сменитьАккаунтToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1060, 33);
            menuStrip1.TabIndex = 15;
            // 
            // назадToolStripMenuItem
            // 
            назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            назадToolStripMenuItem.Size = new Size(77, 29);
            назадToolStripMenuItem.Text = "Назад";
            назадToolStripMenuItem.Click += назадToolStripMenuItem_Click;
            // 
            // сменитьАккаунтToolStripMenuItem
            // 
            сменитьАккаунтToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Size = new Size(164, 29);
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            сменитьАккаунтToolStripMenuItem.Click += сменитьАккаунтToolStripMenuItem_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(30, 45);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(307, 48);
            labelTitle.TabIndex = 14;
            labelTitle.Text = "Приемка товара";
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 11F);
            labelLogin.Location = new Point(800, 5);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(80, 30);
            labelLogin.TabIndex = 13;
            labelLogin.Text = "Логин:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.Location = new Point(30, 108);
            labelName.Name = "labelName";
            labelName.Size = new Size(125, 32);
            labelName.TabIndex = 12;
            labelName.Text = "Название:";
            // 
            // comboBoxName
            // 
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.Font = new Font("Segoe UI", 11F);
            comboBoxName.Location = new Point(200, 108);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(240, 38);
            comboBoxName.TabIndex = 11;
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Font = new Font("Segoe UI", 12F);
            labelCount.Location = new Point(30, 160);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(149, 32);
            labelCount.TabIndex = 10;
            labelCount.Text = "Количество:";
            // 
            // numCount
            // 
            numCount.Font = new Font("Segoe UI", 11F);
            numCount.Location = new Point(200, 160);
            numCount.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numCount.Name = "numCount";
            numCount.Size = new Size(240, 37);
            numCount.TabIndex = 9;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 12F);
            labelPrice.Location = new Point(30, 212);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(170, 32);
            labelPrice.TabIndex = 8;
            labelPrice.Text = "Цена закупки:";
            // 
            // numPrice
            // 
            numPrice.Font = new Font("Segoe UI", 11F);
            numPrice.Location = new Point(200, 212);
            numPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(240, 37);
            numPrice.TabIndex = 7;
            // 
            // labelProvider
            // 
            labelProvider.AutoSize = true;
            labelProvider.Font = new Font("Segoe UI", 12F);
            labelProvider.Location = new Point(30, 264);
            labelProvider.Name = "labelProvider";
            labelProvider.Size = new Size(142, 32);
            labelProvider.TabIndex = 6;
            labelProvider.Text = "Поставщик:";
            // 
            // comboBoxProviderName
            // 
            comboBoxProviderName.Font = new Font("Segoe UI", 11F);
            comboBoxProviderName.Location = new Point(200, 263);
            comboBoxProviderName.Name = "comboBoxProviderName";
            comboBoxProviderName.Size = new Size(240, 38);
            comboBoxProviderName.TabIndex = 5;
            // 
            // buttonCheckApi
            // 
            buttonCheckApi.BackColor = Color.White;
            buttonCheckApi.FlatAppearance.BorderColor = Color.SteelBlue;
            buttonCheckApi.FlatStyle = FlatStyle.Flat;
            buttonCheckApi.Font = new Font("Segoe UI", 12F);
            buttonCheckApi.ForeColor = Color.SteelBlue;
            buttonCheckApi.Location = new Point(12, 330);
            buttonCheckApi.Name = "buttonCheckApi";
            buttonCheckApi.Size = new Size(224, 46);
            buttonCheckApi.TabIndex = 4;
            buttonCheckApi.Text = "Проверить по API";
            buttonCheckApi.UseVisualStyleBackColor = false;
            buttonCheckApi.Click += buttonCheckApi_Click;
            // 
            // buttonAddToBusket
            // 
            buttonAddToBusket.BackColor = Color.SteelBlue;
            buttonAddToBusket.FlatAppearance.BorderSize = 0;
            buttonAddToBusket.FlatStyle = FlatStyle.Flat;
            buttonAddToBusket.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonAddToBusket.ForeColor = Color.White;
            buttonAddToBusket.Location = new Point(242, 330);
            buttonAddToBusket.Name = "buttonAddToBusket";
            buttonAddToBusket.Size = new Size(180, 46);
            buttonAddToBusket.TabIndex = 16;
            buttonAddToBusket.Text = "Добавить";
            buttonAddToBusket.UseVisualStyleBackColor = false;
            buttonAddToBusket.Click += buttonAddToBusket_Click;
            // 
            // labelBusket
            // 
            labelBusket.AutoSize = true;
            labelBusket.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelBusket.Location = new Point(520, 45);
            labelBusket.Name = "labelBusket";
            labelBusket.Size = new Size(146, 48);
            labelBusket.TabIndex = 3;
            labelBusket.Text = "Список";
            // 
            // labelImport
            // 
            labelImport.AutoSize = true;
            labelImport.Font = new Font("Segoe UI", 12F);
            labelImport.Location = new Point(520, 510);
            labelImport.Name = "labelImport";
            labelImport.Size = new Size(212, 32);
            labelImport.TabIndex = 2;
            labelImport.Text = "Импорт из файла:";
            // 
            // buttonImport
            // 
            buttonImport.BackColor = Color.White;
            buttonImport.FlatAppearance.BorderColor = Color.SteelBlue;
            buttonImport.FlatStyle = FlatStyle.Flat;
            buttonImport.Font = new Font("Segoe UI", 11F);
            buttonImport.ForeColor = Color.Black;
            buttonImport.Location = new Point(738, 508);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(201, 38);
            buttonImport.TabIndex = 1;
            buttonImport.Text = "Импортировать";
            buttonImport.UseVisualStyleBackColor = false;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.SteelBlue;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonConfirm.ForeColor = Color.White;
            buttonConfirm.Location = new Point(520, 556);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(330, 42);
            buttonConfirm.TabIndex = 0;
            buttonConfirm.Text = "Подтвердить приёмку";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // AcceptanceOfGoodsForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(1060, 620);
            Controls.Add(buttonConfirm);
            Controls.Add(buttonImport);
            Controls.Add(labelImport);
            Controls.Add(labelBusket);
            Controls.Add(buttonAddToBusket);
            Controls.Add(buttonCheckApi);
            Controls.Add(comboBoxProviderName);
            Controls.Add(labelProvider);
            Controls.Add(numPrice);
            Controls.Add(labelPrice);
            Controls.Add(numCount);
            Controls.Add(labelCount);
            Controls.Add(comboBoxName);
            Controls.Add(labelName);
            Controls.Add(labelLogin);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AcceptanceOfGoodsForm";
            Text = "Принять поставку";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((ISupportInitialize)numCount).EndInit();
            ((ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}