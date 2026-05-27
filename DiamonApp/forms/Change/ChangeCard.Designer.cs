namespace Draft_Diamond_BD
{
    partial class ChangeCard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSelectProduct;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numePurchasePrise;
        private System.Windows.Forms.Label labelUnite;
        private System.Windows.Forms.ComboBox comboBoxUniteOfMeasure;
        private System.Windows.Forms.Button buttonChange;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            backToolStripMenuItem = new ToolStripMenuItem();
            labelTitle = new Label();
            labelSelectProduct = new Label();
            comboBoxName = new ComboBox();
            labelPrice = new Label();
            numePurchasePrise = new NumericUpDown();
            labelUnite = new Label();
            comboBoxUniteOfMeasure = new ComboBox();
            buttonChange = new Button();
            menuStrip1.SuspendLayout();
            ((ISupportInitialize)numePurchasePrise).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(460, 33);
            menuStrip1.TabIndex = 8;
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(77, 29);
            backToolStripMenuItem.Text = "Назад";
            backToolStripMenuItem.Click += BackToolStripMenuItem_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(100, 45);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(302, 48);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Изменить товар";
            // 
            // labelSelectProduct
            // 
            labelSelectProduct.AutoSize = true;
            labelSelectProduct.Font = new Font("Segoe UI", 11F);
            labelSelectProduct.Location = new Point(50, 100);
            labelSelectProduct.Name = "labelSelectProduct";
            labelSelectProduct.Size = new Size(183, 30);
            labelSelectProduct.TabIndex = 6;
            labelSelectProduct.Text = "Выберите товар:";
            // 
            // comboBoxName
            // 
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.Font = new Font("Segoe UI", 11F);
            comboBoxName.Location = new Point(50, 133);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(360, 38);
            comboBoxName.TabIndex = 5;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 11F);
            labelPrice.Location = new Point(50, 175);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(222, 30);
            labelPrice.TabIndex = 4;
            labelPrice.Text = "Новая цена закупки:";
            // 
            // numePurchasePrise
            // 
            numePurchasePrise.Font = new Font("Segoe UI", 11F);
            numePurchasePrise.Location = new Point(50, 208);
            numePurchasePrise.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numePurchasePrise.Name = "numePurchasePrise";
            numePurchasePrise.Size = new Size(360, 37);
            numePurchasePrise.TabIndex = 3;
            // 
            // labelUnite
            // 
            labelUnite.AutoSize = true;
            labelUnite.Font = new Font("Segoe UI", 11F);
            labelUnite.Location = new Point(50, 250);
            labelUnite.Name = "labelUnite";
            labelUnite.Size = new Size(222, 30);
            labelUnite.TabIndex = 2;
            labelUnite.Text = "Единица измерения:";
            // 
            // comboBoxUniteOfMeasure
            // 
            comboBoxUniteOfMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUniteOfMeasure.Font = new Font("Segoe UI", 11F);
            comboBoxUniteOfMeasure.Location = new Point(50, 283);
            comboBoxUniteOfMeasure.Name = "comboBoxUniteOfMeasure";
            comboBoxUniteOfMeasure.Size = new Size(360, 38);
            comboBoxUniteOfMeasure.TabIndex = 1;
            // 
            // buttonChange
            // 
            buttonChange.BackColor = Color.SteelBlue;
            buttonChange.FlatAppearance.BorderSize = 0;
            buttonChange.FlatStyle = FlatStyle.Flat;
            buttonChange.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonChange.ForeColor = Color.White;
            buttonChange.Location = new Point(130, 345);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(200, 44);
            buttonChange.TabIndex = 0;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = false;
            // 
            // ChangeCard
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(460, 435);
            Controls.Add(buttonChange);
            Controls.Add(comboBoxUniteOfMeasure);
            Controls.Add(labelUnite);
            Controls.Add(numePurchasePrise);
            Controls.Add(labelPrice);
            Controls.Add(comboBoxName);
            Controls.Add(labelSelectProduct);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "ChangeCard";
            Text = "Изменить товар";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((ISupportInitialize)numePurchasePrise).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}