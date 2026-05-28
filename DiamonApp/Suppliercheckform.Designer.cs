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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            labelInn = new System.Windows.Forms.Label();
            textBoxInn = new System.Windows.Forms.TextBox();
            buttonSearch = new System.Windows.Forms.Button();
            labelInfoTitle = new System.Windows.Forms.Label();
            richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            labelQuestion = new System.Windows.Forms.Label();
            buttonYes = new System.Windows.Forms.Button();
            buttonNo = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();

            // menuStrip
            menuStrip1.BackColor = System.Drawing.Color.White;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { backToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(580, 28);

            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Text = "Назад";
            backToolStripMenuItem.Click += backToolStripMenuItem_Click;

            // ИНН контрагента
            labelInn.AutoSize = true;
            labelInn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            labelInn.Location = new System.Drawing.Point(30, 45);
            labelInn.Text = "ИНН контрагента:";

            textBoxInn.Font = new System.Drawing.Font("Segoe UI", 13F);
            textBoxInn.Location = new System.Drawing.Point(230, 42);
            textBoxInn.Size = new System.Drawing.Size(300, 34);
            textBoxInn.Name = "textBoxInn";
            textBoxInn.MaxLength = 12;

            // Кнопка поиска — справа от поля (или Enter)
            buttonSearch.BackColor = System.Drawing.Color.SteelBlue;
            buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            buttonSearch.ForeColor = System.Drawing.Color.White;
            buttonSearch.Location = new System.Drawing.Point(540, 40);
            buttonSearch.Size = new System.Drawing.Size(30, 38);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Text = "▶";

            // Заголовок блока информации
            labelInfoTitle.AutoSize = true;
            labelInfoTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelInfoTitle.Location = new System.Drawing.Point(30, 95);
            labelInfoTitle.Text = "Информация о поставщике";

            // Блок с информацией
            richTextBoxInfo.BackColor = System.Drawing.Color.AliceBlue;
            richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            richTextBoxInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            richTextBoxInfo.Location = new System.Drawing.Point(20, 122);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.ReadOnly = true;
            richTextBoxInfo.Size = new System.Drawing.Size(540, 270);
            richTextBoxInfo.Text = "";

            // Вопрос
            labelQuestion.AutoSize = true;
            labelQuestion.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelQuestion.Location = new System.Drawing.Point(30, 410);
            labelQuestion.Text = "Хотите добавить приёмку товара от поставщика?";

            // Кнопка Да
            buttonYes.BackColor = System.Drawing.Color.LightGreen;
            buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonYes.FlatAppearance.BorderSize = 0;
            buttonYes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            buttonYes.Location = new System.Drawing.Point(80, 450);
            buttonYes.Size = new System.Drawing.Size(160, 52);
            buttonYes.Name = "buttonYes";
            buttonYes.Text = "Да";
            buttonYes.Enabled = false;
            buttonYes.Click += buttonYes_Click;

            // Кнопка Нет
            buttonNo.BackColor = System.Drawing.Color.IndianRed;
            buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonNo.FlatAppearance.BorderSize = 0;
            buttonNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            buttonNo.ForeColor = System.Drawing.Color.White;
            buttonNo.Location = new System.Drawing.Point(340, 450);
            buttonNo.Size = new System.Drawing.Size(160, 52);
            buttonNo.Name = "buttonNo";
            buttonNo.Text = "Нет";
            buttonNo.Click += buttonNo_Click;

            // Form
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(580, 530);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(labelQuestion);
            Controls.Add(richTextBoxInfo);
            Controls.Add(labelInfoTitle);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxInn);
            Controls.Add(labelInn);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SupplierCheckForm";
            Text = "Проверка по API";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}