namespace Draft_Diamond_BD
{
    partial class WarehouseStorekeeper
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelwarehouse;
        private System.Windows.Forms.MenuStrip menuStripWarehouseProducts;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItemFilter;
        private System.Windows.Forms.ToolStripMenuItem весьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemOutput;
        private System.Windows.Forms.ToolStripMenuItem сменитьАккаунтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createShipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem принятьПоставкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCurrency;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelResult;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.labelwarehouse = new System.Windows.Forms.Label();
            this.menuStripWarehouseProducts = new System.Windows.Forms.MenuStrip();
            this.filterToolStripMenuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.весьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createShipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.принятьПоставкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItemOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьАккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.menuStripWarehouseProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelwarehouse
            // 
            this.labelwarehouse.AutoSize = true;
            this.labelwarehouse.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelwarehouse.Location = new System.Drawing.Point(20, 42);
            this.labelwarehouse.Name = "labelwarehouse";
            this.labelwarehouse.Size = new System.Drawing.Size(104, 32);
            this.labelwarehouse.TabIndex = 0;
            this.labelwarehouse.Text = "Склад:";
            // 
            // menuStripWarehouseProducts
            // 
            this.menuStripWarehouseProducts.BackColor = System.Drawing.Color.White;
            this.menuStripWarehouseProducts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripWarehouseProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItemFilter,
            this.createShipmentToolStripMenuItem,
            this.принятьПоставкуToolStripMenuItem,
            this.toolStripMenuItemCurrency,
            this.exitToolStripMenuItemOutput,
            this.сменитьАккаунтToolStripMenuItem});
            this.menuStripWarehouseProducts.Location = new System.Drawing.Point(0, 0);
            this.menuStripWarehouseProducts.Name = "menuStripWarehouseProducts";
            this.menuStripWarehouseProducts.Size = new System.Drawing.Size(1100, 28);
            this.menuStripWarehouseProducts.TabIndex = 1;
            this.menuStripWarehouseProducts.Text = "menuStripWarehouseProducts";
            // 
            // filterToolStripMenuItemFilter
            // 
            this.filterToolStripMenuItemFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.весьСкладToolStripMenuItem,
            this.категорииToolStripMenuItem});
            this.filterToolStripMenuItemFilter.Name = "filterToolStripMenuItemFilter";
            this.filterToolStripMenuItemFilter.Size = new System.Drawing.Size(62, 24);
            this.filterToolStripMenuItemFilter.Text = "Фильтр";
            // 
            // весьСкладToolStripMenuItem
            // 
            this.весьСкладToolStripMenuItem.Name = "весьСкладToolStripMenuItem";
            this.весьСкладToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.весьСкладToolStripMenuItem.Text = "Весь склад";
            // 
            // категорииToolStripMenuItem
            // 
            this.категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            this.категорииToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.категорииToolStripMenuItem.Text = "Категории";
            // 
            // createShipmentToolStripMenuItem
            // 
            this.createShipmentToolStripMenuItem.Name = "createShipmentToolStripMenuItem";
            this.createShipmentToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.createShipmentToolStripMenuItem.Text = "Создать отгрузку";
            // 
            // принятьПоставкуToolStripMenuItem
            // 
            this.принятьПоставкуToolStripMenuItem.Name = "принятьПоставкуToolStripMenuItem";
            this.принятьПоставкуToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.принятьПоставкуToolStripMenuItem.Text = "Принять поставку";
            // 
            // toolStripMenuItemCurrency
            // 
            this.toolStripMenuItemCurrency.Name = "toolStripMenuItemCurrency";
            this.toolStripMenuItemCurrency.Size = new System.Drawing.Size(133, 24);
            this.toolStripMenuItemCurrency.Text = "Настроить валюту";
            // 
            // exitToolStripMenuItemOutput
            // 
            this.exitToolStripMenuItemOutput.Name = "exitToolStripMenuItemOutput";
            this.exitToolStripMenuItemOutput.Size = new System.Drawing.Size(62, 24);
            this.exitToolStripMenuItemOutput.Text = "Выход";
            // 
            // сменитьАккаунтToolStripMenuItem
            // 
            this.сменитьАккаунтToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            this.сменитьАккаунтToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelLogin.Location = new System.Drawing.Point(820, 5);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(61, 20);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Логин:";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelResult.Location = new System.Drawing.Point(20, 680);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 23);
            this.labelResult.TabIndex = 8;
            // 
            // WarehouseStorekeeper
            // 
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelwarehouse);
            this.Controls.Add(this.menuStripWarehouseProducts);
            this.MainMenuStrip = this.menuStripWarehouseProducts;
            this.Name = "WarehouseStorekeeper";
            this.Text = "Склад кладовщика";
            this.menuStripWarehouseProducts.ResumeLayout(false);
            this.menuStripWarehouseProducts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}