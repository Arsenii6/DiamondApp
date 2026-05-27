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
        private System.Windows.Forms.Label labelBusket;
        private System.Windows.Forms.Label labelImport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button button1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            сменитьАккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            labelTitle = new System.Windows.Forms.Label();
            labelLogin = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();
            comboBoxName = new System.Windows.Forms.ComboBox();
            labelCount = new System.Windows.Forms.Label();
            numCount = new System.Windows.Forms.NumericUpDown();
            labelPrice = new System.Windows.Forms.Label();
            numPrice = new System.Windows.Forms.NumericUpDown();
            labelProvider = new System.Windows.Forms.Label();
            comboBoxProviderName = new System.Windows.Forms.ComboBox();
            buttonCheckApi = new System.Windows.Forms.Button();
            labelBusket = new System.Windows.Forms.Label();
            labelImport = new System.Windows.Forms.Label();
            buttonImport = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();

            // ── MenuStrip ──────────────────────────────────────────────────────
            menuStrip1.BackColor = System.Drawing.Color.White;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                { назадToolStripMenuItem, сменитьАккаунтToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1060, 28);

            назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            назадToolStripMenuItem.Text = "Назад";
            назадToolStripMenuItem.Click += назадToolStripMenuItem_Click;

            сменитьАккаунтToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            сменитьАккаунтToolStripMenuItem.Click += сменитьАккаунтToolStripMenuItem_Click;

            // ── Заголовок левого блока ─────────────────────────────────────────
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(30, 45);
            labelTitle.Text = "Приемка товара";

            // ── Логин справа ──────────────────────────────────────────────────
            labelLogin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelLogin.Location = new System.Drawing.Point(750, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Text = "Логин:";

            // ── Название ──────────────────────────────────────────────────────
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelName.Location = new System.Drawing.Point(30, 108);
            labelName.Text = "Название:";

            comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxName.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBoxName.Location = new System.Drawing.Point(170, 106);
            comboBoxName.Size = new System.Drawing.Size(240, 30);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;

            // ── Количество ────────────────────────────────────────────────────
            labelCount.AutoSize = true;
            labelCount.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelCount.Location = new System.Drawing.Point(30, 160);
            labelCount.Text = "Количество:";

            numCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            numCount.Location = new System.Drawing.Point(170, 158);
            numCount.Size = new System.Drawing.Size(240, 30);
            numCount.Minimum = 0;
            numCount.Maximum = 99999;
            numCount.Name = "numCount";

            // ── Цена закупки ──────────────────────────────────────────────────
            labelPrice.AutoSize = true;
            labelPrice.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelPrice.Location = new System.Drawing.Point(30, 212);
            labelPrice.Text = "Цена закупки:";

            numPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            numPrice.Location = new System.Drawing.Point(170, 210);
            numPrice.Size = new System.Drawing.Size(240, 30);
            numPrice.Maximum = 9999999;
            numPrice.Name = "numPrice";

            // ── Поставщик ─────────────────────────────────────────────────────
            labelProvider.AutoSize = true;
            labelProvider.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelProvider.Location = new System.Drawing.Point(30, 264);
            labelProvider.Text = "Поставщик:";

            comboBoxProviderName.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBoxProviderName.Location = new System.Drawing.Point(170, 262);
            comboBoxProviderName.Size = new System.Drawing.Size(240, 30);
            comboBoxProviderName.Name = "comboBoxProviderName";

            // ── Кнопка Проверить по API ───────────────────────────────────────
            buttonCheckApi.BackColor = System.Drawing.Color.White;
            buttonCheckApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCheckApi.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            buttonCheckApi.Font = new System.Drawing.Font("Segoe UI", 12F);
            buttonCheckApi.ForeColor = System.Drawing.Color.SteelBlue;
            buttonCheckApi.Location = new System.Drawing.Point(30, 330);
            buttonCheckApi.Size = new System.Drawing.Size(220, 46);
            buttonCheckApi.Name = "buttonCheckApi";
            buttonCheckApi.Text = "Проверить по API";
            buttonCheckApi.UseVisualStyleBackColor = false;
            buttonCheckApi.Click += buttonCheckApi_Click;

            // ── Правый блок — заголовок ───────────────────────────────────────
            labelBusket.AutoSize = true;
            labelBusket.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelBusket.Location = new System.Drawing.Point(520, 45);
            labelBusket.Text = "Список";

            // ── Импорт из файла ───────────────────────────────────────────────
            labelImport.AutoSize = true;
            labelImport.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelImport.Location = new System.Drawing.Point(520, 510);
            labelImport.Text = "Импорт из файла:";

            buttonImport.BackColor = System.Drawing.Color.White;
            buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonImport.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            buttonImport.Font = new System.Drawing.Font("Segoe UI", 11F);
            buttonImport.ForeColor = System.Drawing.Color.Black;
            buttonImport.Location = new System.Drawing.Point(700, 506);
            buttonImport.Size = new System.Drawing.Size(150, 38);
            buttonImport.Name = "buttonImport";
            buttonImport.Text = "Импортировать";
            buttonImport.Click += buttonImport_Click;

            // ── Кнопка Добавить в корзину (button1 = подтверждение приёмки) ──
            button1.BackColor = System.Drawing.Color.SteelBlue;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(520, 556);
            button1.Size = new System.Drawing.Size(330, 42);
            button1.Name = "button1";
            button1.Text = "Подтвердить приёмку";
            button1.Click += button1_Click;

            // ── Form ──────────────────────────────────────────────────────────
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(1060, 620);
            Controls.Add(button1);
            Controls.Add(buttonImport);
            Controls.Add(labelImport);
            Controls.Add(labelBusket);
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
            ((System.ComponentModel.ISupportInitialize)numCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}