namespace DiamonApp.forms
{
    partial class AddCategory
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonAdd;

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
            labelName = new Label();
            textBoxName = new TextBox();
            buttonAdd = new Button();
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
            menuStrip1.Size = new Size(420, 33);
            menuStrip1.TabIndex = 4;
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
            labelTitle.Location = new Point(12, 42);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(387, 48);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "Добавить категорию";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 11F);
            labelName.Location = new Point(50, 110);
            labelName.Name = "labelName";
            labelName.Size = new Size(225, 30);
            labelName.TabIndex = 2;
            labelName.Text = "Название категории:";
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 11F);
            textBoxName.Location = new Point(50, 143);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(320, 37);
            textBoxName.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.SteelBlue;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(110, 205);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(200, 44);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            // 
            // AddCategory
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(420, 300);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "AddCategory";
            Text = "Добавить категорию";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}