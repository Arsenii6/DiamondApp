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
            comboBoxCurrency = new System.Windows.Forms.ComboBox();
            buttonUpdate = new System.Windows.Forms.Button();
            labelRate = new System.Windows.Forms.Label();
            labelTitle = new System.Windows.Forms.Label();
            labelCurrencyCaption = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { backToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(440, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            backToolStripMenuItem.Text = "Назад";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(90, 45);
            labelTitle.Name = "labelTitle";
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Настройки валют";
            // 
            // labelCurrencyCaption
            // 
            labelCurrencyCaption.AutoSize = true;
            labelCurrencyCaption.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelCurrencyCaption.Location = new System.Drawing.Point(30, 110);
            labelCurrencyCaption.Name = "labelCurrencyCaption";
            labelCurrencyCaption.TabIndex = 2;
            labelCurrencyCaption.Text = "Выберите валюту:";
            // 
            // comboBoxCurrency
            // 
            comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxCurrency.FormattingEnabled = true;
            comboBoxCurrency.Location = new System.Drawing.Point(185, 108);
            comboBoxCurrency.Name = "comboBoxCurrency";
            comboBoxCurrency.Size = new System.Drawing.Size(200, 28);
            comboBoxCurrency.TabIndex = 3;
            // 
            // labelRate
            // 
            labelRate.AutoSize = true;
            labelRate.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelRate.ForeColor = System.Drawing.Color.DarkGreen;
            labelRate.Location = new System.Drawing.Point(30, 158);
            labelRate.Name = "labelRate";
            labelRate.TabIndex = 4;
            labelRate.Text = "";
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            buttonUpdate.Font = new System.Drawing.Font("Segoe UI", 12F);
            buttonUpdate.ForeColor = System.Drawing.Color.White;
            buttonUpdate.Location = new System.Drawing.Point(150, 200);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new System.Drawing.Size(140, 40);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // CurrencySettings
            // 
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(440, 300);
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