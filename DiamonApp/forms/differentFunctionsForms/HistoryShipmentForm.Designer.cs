namespace DiamonApp.forms.differentFunctionsForms
{
    partial class HistoryShipmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.ComboBox comboBoxFiter;
        private System.Windows.Forms.Button buttonExportTheReport;
        private System.Windows.Forms.Button buttonListWaredhouse;

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
            labelLogin = new Label();
            labelDateFrom = new Label();
            date1 = new DateTimePicker();
            labelDateTo = new Label();
            date2 = new DateTimePicker();
            buttonShow = new Button();
            labelFilter = new Label();
            comboBoxFiter = new ComboBox();
            buttonExportTheReport = new Button();
            buttonListWaredhouse = new Button();
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
            menuStrip1.Size = new Size(1100, 33);
            menuStrip1.TabIndex = 11;
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(77, 29);
            backToolStripMenuItem.Text = "Назад";
            backToolStripMenuItem.Click += buttonListWaredhouse_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(30, 42);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(329, 48);
            labelTitle.TabIndex = 10;
            labelTitle.Text = "История отгрузок";
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 11F);
            labelLogin.Location = new Point(850, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(80, 30);
            labelLogin.TabIndex = 9;
            labelLogin.Text = "Логин:";
            // 
            // labelDateFrom
            // 
            labelDateFrom.AutoSize = true;
            labelDateFrom.Font = new Font("Segoe UI", 11F);
            labelDateFrom.Location = new Point(30, 95);
            labelDateFrom.Name = "labelDateFrom";
            labelDateFrom.Size = new Size(32, 30);
            labelDateFrom.TabIndex = 8;
            labelDateFrom.Text = "С:";
            // 
            // date1
            // 
            date1.Font = new Font("Segoe UI", 11F);
            date1.Location = new Point(55, 92);
            date1.Name = "date1";
            date1.Size = new Size(180, 37);
            date1.TabIndex = 7;
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Font = new Font("Segoe UI", 11F);
            labelDateTo.Location = new Point(241, 97);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(47, 30);
            labelDateTo.TabIndex = 6;
            labelDateTo.Text = "По:";
            // 
            // date2
            // 
            date2.Font = new Font("Segoe UI", 11F);
            date2.Location = new Point(282, 92);
            date2.Name = "date2";
            date2.Size = new Size(180, 37);
            date2.TabIndex = 5;
            // 
            // buttonShow
            // 
            buttonShow.BackColor = Color.SteelBlue;
            buttonShow.FlatAppearance.BorderSize = 0;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonShow.ForeColor = Color.White;
            buttonShow.Location = new Point(480, 88);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(140, 36);
            buttonShow.TabIndex = 4;
            buttonShow.Text = "Показать";
            buttonShow.UseVisualStyleBackColor = false;
            buttonShow.Click += buttonShow_Click;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Font = new Font("Segoe UI", 11F);
            labelFilter.Location = new Point(650, 95);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(133, 30);
            labelFilter.TabIndex = 3;
            labelFilter.Text = "Кладовщик:";
            // 
            // comboBoxFiter
            // 
            comboBoxFiter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiter.Font = new Font("Segoe UI", 11F);
            comboBoxFiter.Location = new Point(789, 92);
            comboBoxFiter.Name = "comboBoxFiter";
            comboBoxFiter.Size = new Size(200, 38);
            comboBoxFiter.TabIndex = 2;
            // 
            // buttonExportTheReport
            // 
            buttonExportTheReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonExportTheReport.BackColor = Color.SteelBlue;
            buttonExportTheReport.FlatAppearance.BorderSize = 0;
            buttonExportTheReport.FlatStyle = FlatStyle.Flat;
            buttonExportTheReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonExportTheReport.ForeColor = Color.White;
            buttonExportTheReport.Location = new Point(30, 510);
            buttonExportTheReport.Name = "buttonExportTheReport";
            buttonExportTheReport.Size = new Size(200, 42);
            buttonExportTheReport.TabIndex = 1;
            buttonExportTheReport.Text = "Экспорт в CSV";
            buttonExportTheReport.UseVisualStyleBackColor = false;
            buttonExportTheReport.Click += buttonExportTheReport_Click;
            // 
            // buttonListWaredhouse
            // 
            buttonListWaredhouse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonListWaredhouse.BackColor = Color.White;
            buttonListWaredhouse.FlatAppearance.BorderColor = Color.SteelBlue;
            buttonListWaredhouse.FlatStyle = FlatStyle.Flat;
            buttonListWaredhouse.Font = new Font("Segoe UI", 11F);
            buttonListWaredhouse.ForeColor = Color.SteelBlue;
            buttonListWaredhouse.Location = new Point(250, 510);
            buttonListWaredhouse.Name = "buttonListWaredhouse";
            buttonListWaredhouse.Size = new Size(200, 42);
            buttonListWaredhouse.TabIndex = 0;
            buttonListWaredhouse.Text = "← На склад";
            buttonListWaredhouse.UseVisualStyleBackColor = false;
            buttonListWaredhouse.Click += buttonListWaredhouse_Click;
            // 
            // HistoryShipmentForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(1100, 580);
            Controls.Add(buttonListWaredhouse);
            Controls.Add(buttonExportTheReport);
            Controls.Add(comboBoxFiter);
            Controls.Add(labelFilter);
            Controls.Add(buttonShow);
            Controls.Add(date2);
            Controls.Add(labelDateTo);
            Controls.Add(date1);
            Controls.Add(labelDateFrom);
            Controls.Add(labelLogin);
            Controls.Add(labelTitle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HistoryShipmentForm";
            Text = "История отгрузок";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}