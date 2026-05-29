namespace DiamonApp.forms.differentFunctionsForms
{
    partial class CurrencySettings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelCurrencyCaption;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            comboBoxCurrency = new ComboBox();
            buttonUpdate = new Button();
            labelRate = new Label();
            labelTitle = new Label();
            labelCurrencyCaption = new Label();
            menuStrip1 = new MenuStrip();
            backToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCurrency
            // 
            comboBoxCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCurrency.FormattingEnabled = true;
            comboBoxCurrency.Location = new Point(204, 111);
            comboBoxCurrency.Name = "comboBoxCurrency";
            comboBoxCurrency.Size = new Size(200, 33);
            comboBoxCurrency.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = SystemColors.ControlDarkDark;
            buttonUpdate.Font = new Font("Segoe UI", 12F);
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(150, 200);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(140, 40);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // labelRate
            // 
            labelRate.AutoSize = true;
            labelRate.Font = new Font("Segoe UI", 11F);
            labelRate.ForeColor = Color.DarkGreen;
            labelRate.Location = new Point(30, 158);
            labelRate.Name = "labelRate";
            labelRate.Size = new Size(0, 30);
            labelRate.TabIndex = 4;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.Location = new Point(64, 43);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(297, 45);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Настройки валют";
            // 
            // labelCurrencyCaption
            // 
            labelCurrencyCaption.AutoSize = true;
            labelCurrencyCaption.Font = new Font("Segoe UI", 11F);
            labelCurrencyCaption.Location = new Point(0, 110);
            labelCurrencyCaption.Name = "labelCurrencyCaption";
            labelCurrencyCaption.Size = new Size(198, 30);
            labelCurrencyCaption.TabIndex = 2;
            labelCurrencyCaption.Text = "Выберите валюту:";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(440, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(77, 29);
            backToolStripMenuItem.Text = "Назад";
            // 
            // CurrencySettings
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(440, 300);
            Controls.Add(buttonUpdate);
            Controls.Add(labelRate);
            Controls.Add(comboBoxCurrency);
            Controls.Add(labelCurrencyCaption);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CurrencySettings";
            Text = "Настройки валют";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}