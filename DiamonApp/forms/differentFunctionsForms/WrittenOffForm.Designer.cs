namespace Draft_Diamond_BD
{
    partial class WrittenOffForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTotalValue;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelCountValue;
        private System.Windows.Forms.Label labelLoss;
        private System.Windows.Forms.Label labelLossValue;
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
            labelTotal = new Label();
            labelTotalValue = new Label();
            labelCount = new Label();
            labelCountValue = new Label();
            labelLoss = new Label();
            labelLossValue = new Label();
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
            menuStrip1.Size = new Size(1187, 33);
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
            labelTitle.Location = new Point(30, 45);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(338, 48);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Списанный товар:";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTotal.Location = new Point(30, 700);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(74, 28);
            labelTotal.TabIndex = 5;
            labelTotal.Text = "Итого:";
            // 
            // labelTotalValue
            // 
            labelTotalValue.AutoSize = true;
            labelTotalValue.Font = new Font("Segoe UI", 10F);
            labelTotalValue.Location = new Point(100, 700);
            labelTotalValue.Name = "labelTotalValue";
            labelTotalValue.Size = new Size(0, 28);
            labelTotalValue.TabIndex = 4;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCount.Location = new Point(251, 700);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(219, 28);
            labelCount.TabIndex = 3;
            labelCount.Text = "Количество товаров:";
            // 
            // labelCountValue
            // 
            labelCountValue.AutoSize = true;
            labelCountValue.Font = new Font("Segoe UI", 10F);
            labelCountValue.Location = new Point(470, 700);
            labelCountValue.Name = "labelCountValue";
            labelCountValue.Size = new Size(0, 28);
            labelCountValue.TabIndex = 2;
            // 
            // labelLoss
            // 
            labelLoss.AutoSize = true;
            labelLoss.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelLoss.Location = new Point(600, 700);
            labelLoss.Name = "labelLoss";
            labelLoss.Size = new Size(90, 28);
            labelLoss.TabIndex = 1;
            labelLoss.Text = "Убыток:";
            // 
            // labelLossValue
            // 
            labelLossValue.AutoSize = true;
            labelLossValue.Font = new Font("Segoe UI", 10F);
            labelLossValue.Location = new Point(670, 700);
            labelLossValue.Name = "labelLossValue";
            labelLossValue.Size = new Size(0, 28);
            labelLossValue.TabIndex = 0;
            // 
            // WrittenOffForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(1187, 740);
            Controls.Add(labelLossValue);
            Controls.Add(labelLoss);
            Controls.Add(labelCountValue);
            Controls.Add(labelCount);
            Controls.Add(labelTotalValue);
            Controls.Add(labelTotal);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "WrittenOffForm";
            Text = "Склад списанных товаров";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}