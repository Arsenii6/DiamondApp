namespace DiamonApp.forms
{
    partial class DeleteCategory
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Button buttonDeleteCategory;

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
            labelSelect = new Label();
            comboBoxName = new ComboBox();
            buttonDeleteCategory = new Button();
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
            menuStrip1.Size = new Size(460, 33);
            menuStrip1.TabIndex = 4;
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
            labelTitle.Location = new Point(54, 47);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(356, 48);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "Удалить категорию";
            // 
            // labelSelect
            // 
            labelSelect.AutoSize = true;
            labelSelect.Font = new Font("Segoe UI", 11F);
            labelSelect.Location = new Point(50, 105);
            labelSelect.Name = "labelSelect";
            labelSelect.Size = new Size(233, 30);
            labelSelect.TabIndex = 2;
            labelSelect.Text = "Выберите категорию:";
            // 
            // comboBoxName
            // 
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.Font = new Font("Segoe UI", 11F);
            comboBoxName.Location = new Point(50, 138);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(360, 38);
            comboBoxName.TabIndex = 1;
            // 
            // buttonDeleteCategory
            // 
            buttonDeleteCategory.BackColor = Color.Crimson;
            buttonDeleteCategory.FlatAppearance.BorderSize = 0;
            buttonDeleteCategory.FlatStyle = FlatStyle.Flat;
            buttonDeleteCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDeleteCategory.ForeColor = Color.White;
            buttonDeleteCategory.Location = new Point(130, 205);
            buttonDeleteCategory.Name = "buttonDeleteCategory";
            buttonDeleteCategory.Size = new Size(200, 44);
            buttonDeleteCategory.TabIndex = 0;
            buttonDeleteCategory.Text = "Удалить";
            buttonDeleteCategory.UseVisualStyleBackColor = false;
            // 
            // DeleteCategory
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(460, 300);
            Controls.Add(buttonDeleteCategory);
            Controls.Add(comboBoxName);
            Controls.Add(labelSelect);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "DeleteCategory";
            Text = "Удалить категорию";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}