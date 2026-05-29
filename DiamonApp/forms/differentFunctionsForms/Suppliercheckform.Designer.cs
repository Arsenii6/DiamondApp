namespace DiamondApp.forms.differentFunctionsForms
{
    partial class SupplierCheckForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelInn;
        private System.Windows.Forms.TextBox textBoxInn;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelInfoTitle;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            backToolStripMenuItem = new ToolStripMenuItem();
            labelInn = new Label();
            textBoxInn = new TextBox();
            buttonSearch = new Button();
            labelInfoTitle = new Label();
            richTextBoxInfo = new RichTextBox();
            labelQuestion = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(580, 33);
            menuStrip1.TabIndex = 8;
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(77, 29);
            backToolStripMenuItem.Text = "Назад";
            // 
            // labelInn
            // 
            labelInn.AutoSize = true;
            labelInn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelInn.Location = new Point(0, 42);
            labelInn.Name = "labelInn";
            labelInn.Size = new Size(246, 36);
            labelInn.TabIndex = 7;
            labelInn.Text = "ИНН контрагента:";
            // 
            // textBoxInn
            // 
            textBoxInn.Font = new Font("Segoe UI", 13F);
            textBoxInn.Location = new Point(242, 42);
            textBoxInn.MaxLength = 12;
            textBoxInn.Name = "textBoxInn";
            textBoxInn.Size = new Size(288, 42);
            textBoxInn.TabIndex = 6;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.SteelBlue;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(540, 40);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(30, 38);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "▶";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // labelInfoTitle
            // 
            labelInfoTitle.AutoSize = true;
            labelInfoTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelInfoTitle.Location = new Point(20, 87);
            labelInfoTitle.Name = "labelInfoTitle";
            labelInfoTitle.Size = new Size(346, 32);
            labelInfoTitle.TabIndex = 4;
            labelInfoTitle.Text = "Информация о поставщике";
            // 
            // richTextBoxInfo
            // 
            richTextBoxInfo.BackColor = Color.AliceBlue;
            richTextBoxInfo.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxInfo.Font = new Font("Segoe UI", 11F);
            richTextBoxInfo.Location = new Point(20, 122);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.ReadOnly = true;
            richTextBoxInfo.Size = new Size(540, 270);
            richTextBoxInfo.TabIndex = 3;
            richTextBoxInfo.Text = "";
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Font = new Font("Segoe UI", 12F);
            labelQuestion.Location = new Point(16, 405);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(564, 32);
            labelQuestion.TabIndex = 2;
            labelQuestion.Text = "Хотите добавить приёмку товара от поставщика?";
            // 
            // buttonYes
            // 
            buttonYes.BackColor = Color.LightGreen;
            buttonYes.Enabled = false;
            buttonYes.FlatAppearance.BorderSize = 0;
            buttonYes.FlatStyle = FlatStyle.Flat;
            buttonYes.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonYes.Location = new Point(80, 450);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(160, 52);
            buttonYes.TabIndex = 1;
            buttonYes.Text = "Да";
            buttonYes.UseVisualStyleBackColor = false;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.BackColor = Color.IndianRed;
            buttonNo.FlatAppearance.BorderSize = 0;
            buttonNo.FlatStyle = FlatStyle.Flat;
            buttonNo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonNo.ForeColor = Color.White;
            buttonNo.Location = new Point(340, 450);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(160, 52);
            buttonNo.TabIndex = 0;
            buttonNo.Text = "Нет";
            buttonNo.UseVisualStyleBackColor = false;
            buttonNo.Click += buttonNo_Click;
            // 
            // SupplierCheckForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(580, 530);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(labelQuestion);
            Controls.Add(richTextBoxInfo);
            Controls.Add(labelInfoTitle);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxInn);
            Controls.Add(labelInn);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "SupplierCheckForm";
            Text = "Проверка по API";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}