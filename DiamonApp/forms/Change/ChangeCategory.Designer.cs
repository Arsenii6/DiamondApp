namespace DiamonApp.forms
{
    partial class ChangeCategory
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelOld;
        private System.Windows.Forms.ComboBox comboBoxOldName;
        private System.Windows.Forms.Label labelNew;
        private System.Windows.Forms.TextBox comboBoxNewName;
        private System.Windows.Forms.Button buttonChangeCategory;

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
            labelOld = new Label();
            comboBoxOldName = new ComboBox();
            labelNew = new Label();
            comboBoxNewName = new TextBox();
            buttonChangeCategory = new Button();
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
            menuStrip1.TabIndex = 6;
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
            labelTitle.Location = new Point(50, 46);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(389, 48);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Изменить категорию";
            // 
            // labelOld
            // 
            labelOld.AutoSize = true;
            labelOld.Font = new Font("Segoe UI", 11F);
            labelOld.Location = new Point(50, 105);
            labelOld.Name = "labelOld";
            labelOld.Size = new Size(211, 30);
            labelOld.TabIndex = 4;
            labelOld.Text = "Текущая категория:";
            // 
            // comboBoxOldName
            // 
            comboBoxOldName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOldName.Font = new Font("Segoe UI", 11F);
            comboBoxOldName.Location = new Point(50, 138);
            comboBoxOldName.Name = "comboBoxOldName";
            comboBoxOldName.Size = new Size(360, 38);
            comboBoxOldName.TabIndex = 3;
            // 
            // labelNew
            // 
            labelNew.AutoSize = true;
            labelNew.Font = new Font("Segoe UI", 11F);
            labelNew.Location = new Point(50, 180);
            labelNew.Name = "labelNew";
            labelNew.Size = new Size(185, 30);
            labelNew.TabIndex = 2;
            labelNew.Text = "Новое название:";
            // 
            // comboBoxNewName
            // 
            comboBoxNewName.Font = new Font("Segoe UI", 11F);
            comboBoxNewName.Location = new Point(50, 213);
            comboBoxNewName.Name = "comboBoxNewName";
            comboBoxNewName.Size = new Size(360, 37);
            comboBoxNewName.TabIndex = 1;
            // 
            // buttonChangeCategory
            // 
            buttonChangeCategory.BackColor = Color.SteelBlue;
            buttonChangeCategory.FlatAppearance.BorderSize = 0;
            buttonChangeCategory.FlatStyle = FlatStyle.Flat;
            buttonChangeCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonChangeCategory.ForeColor = Color.White;
            buttonChangeCategory.Location = new Point(130, 275);
            buttonChangeCategory.Name = "buttonChangeCategory";
            buttonChangeCategory.Size = new Size(200, 44);
            buttonChangeCategory.TabIndex = 0;
            buttonChangeCategory.Text = "Изменить";
            buttonChangeCategory.UseVisualStyleBackColor = false;
            // 
            // ChangeCategory
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(460, 365);
            Controls.Add(buttonChangeCategory);
            Controls.Add(comboBoxNewName);
            Controls.Add(labelNew);
            Controls.Add(comboBoxOldName);
            Controls.Add(labelOld);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "ChangeCategory";
            Text = "Изменить категорию";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}