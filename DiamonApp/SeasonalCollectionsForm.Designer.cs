namespace Draft_Diamond_BD
{
    partial class SeasonalCollectionsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTypeProduct;
        private System.Windows.Forms.ComboBox comboBoxTypeProduct;
        private System.Windows.Forms.Label labelSeasonDuration;
        private System.Windows.Forms.ComboBox comboBoxSeasonDuration;
        private System.Windows.Forms.Label labelDiscountWeeks;
        private System.Windows.Forms.NumericUpDown numDiscountBeforeEnd;
        private System.Windows.Forms.Label labelDiscountWeeksUnit;
        private System.Windows.Forms.Label labelDiscountValue;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Button buttonSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            backToolStripMenuItem = new ToolStripMenuItem();
            labelTitle = new Label();
            labelTypeProduct = new Label();
            comboBoxTypeProduct = new ComboBox();
            labelSeasonDuration = new Label();
            comboBoxSeasonDuration = new ComboBox();
            labelDiscountWeeks = new Label();
            numDiscountBeforeEnd = new NumericUpDown();
            labelDiscountWeeksUnit = new Label();
            labelDiscountValue = new Label();
            numDiscount = new NumericUpDown();
            buttonSave = new Button();
            menuStrip1.SuspendLayout();
            ((ISupportInitialize)numDiscountBeforeEnd).BeginInit();
            ((ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(560, 33);
            menuStrip1.TabIndex = 0;
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(77, 29);
            backToolStripMenuItem.Text = "Назад";
            backToolStripMenuItem.Click += backToolStripMenuItem_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(73, 46);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(395, 48);
            labelTitle.TabIndex = 20;
            labelTitle.Text = "Сезонные коллекции";
            // 
            // labelTypeProduct
            // 
            labelTypeProduct.AutoSize = true;
            labelTypeProduct.Font = new Font("Segoe UI", 12F);
            labelTypeProduct.Location = new Point(30, 120);
            labelTypeProduct.Name = "labelTypeProduct";
            labelTypeProduct.Size = new Size(142, 32);
            labelTypeProduct.TabIndex = 19;
            labelTypeProduct.Text = "Тип товара:";
            // 
            // comboBoxTypeProduct
            // 
            comboBoxTypeProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypeProduct.FormattingEnabled = true;
            comboBoxTypeProduct.Location = new Point(178, 123);
            comboBoxTypeProduct.Name = "comboBoxTypeProduct";
            comboBoxTypeProduct.Size = new Size(200, 33);
            comboBoxTypeProduct.TabIndex = 18;
            comboBoxTypeProduct.Click += comboBoxTypeProduct_Click;
            // 
            // labelSeasonDuration
            // 
            labelSeasonDuration.AutoSize = true;
            labelSeasonDuration.Font = new Font("Segoe UI", 12F);
            labelSeasonDuration.Location = new Point(30, 175);
            labelSeasonDuration.Name = "labelSeasonDuration";
            labelSeasonDuration.Size = new Size(287, 32);
            labelSeasonDuration.TabIndex = 17;
            labelSeasonDuration.Text = "Срок сезона (в месяцах):";
            // 
            // comboBoxSeasonDuration
            // 
            comboBoxSeasonDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSeasonDuration.FormattingEnabled = true;
            comboBoxSeasonDuration.Items.AddRange(new object[] { "1", "3", "6", "9", "12" });
            comboBoxSeasonDuration.Location = new Point(312, 178);
            comboBoxSeasonDuration.Name = "comboBoxSeasonDuration";
            comboBoxSeasonDuration.Size = new Size(140, 33);
            comboBoxSeasonDuration.TabIndex = 16;
            // 
            // labelDiscountWeeks
            // 
            labelDiscountWeeks.AutoSize = true;
            labelDiscountWeeks.Font = new Font("Segoe UI", 12F);
            labelDiscountWeeks.Location = new Point(30, 230);
            labelDiscountWeeks.Name = "labelDiscountWeeks";
            labelDiscountWeeks.Size = new Size(273, 32);
            labelDiscountWeeks.TabIndex = 15;
            labelDiscountWeeks.Text = "Скидка применяется за";
            // 
            // numDiscountBeforeEnd
            // 
            numDiscountBeforeEnd.Location = new Point(266, 234);
            numDiscountBeforeEnd.Maximum = new decimal(new int[] { 52, 0, 0, 0 });
            numDiscountBeforeEnd.Name = "numDiscountBeforeEnd";
            numDiscountBeforeEnd.Size = new Size(120, 31);
            numDiscountBeforeEnd.TabIndex = 14;
            // 
            // labelDiscountWeeksUnit
            // 
            labelDiscountWeeksUnit.AutoSize = true;
            labelDiscountWeeksUnit.Font = new Font("Segoe UI", 12F);
            labelDiscountWeeksUnit.Location = new Point(380, 230);
            labelDiscountWeeksUnit.Name = "labelDiscountWeeksUnit";
            labelDiscountWeeksUnit.Size = new Size(137, 32);
            labelDiscountWeeksUnit.TabIndex = 11;
            labelDiscountWeeksUnit.Text = "(в неделях)";
            // 
            // labelDiscountValue
            // 
            labelDiscountValue.AutoSize = true;
            labelDiscountValue.Font = new Font("Segoe UI", 12F);
            labelDiscountValue.Location = new Point(30, 285);
            labelDiscountValue.Name = "labelDiscountValue";
            labelDiscountValue.Size = new Size(205, 32);
            labelDiscountValue.TabIndex = 13;
            labelDiscountValue.Text = "До конца сезона:";
            // 
            // numDiscount
            // 
            numDiscount.Location = new Point(241, 289);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(140, 31);
            numDiscount.TabIndex = 12;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.LightGreen;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            buttonSave.Location = new Point(130, 370);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(300, 50);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить настройки";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // SeasonalCollectionsForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(560, 460);
            Controls.Add(buttonSave);
            Controls.Add(labelDiscountWeeksUnit);
            Controls.Add(numDiscount);
            Controls.Add(labelDiscountValue);
            Controls.Add(numDiscountBeforeEnd);
            Controls.Add(labelDiscountWeeks);
            Controls.Add(comboBoxSeasonDuration);
            Controls.Add(labelSeasonDuration);
            Controls.Add(comboBoxTypeProduct);
            Controls.Add(labelTypeProduct);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SeasonalCollectionsForm";
            Text = "Сезонные коллекции";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((ISupportInitialize)numDiscountBeforeEnd).EndInit();
            ((ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}