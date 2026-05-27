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
            labelwarehouse = new System.Windows.Forms.Label();
            menuStripWarehouseProducts = new System.Windows.Forms.MenuStrip();
            filterToolStripMenuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
            весьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItemOutput = new System.Windows.Forms.ToolStripMenuItem();
            сменитьАккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            createShipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            принятьПоставкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            labelLogin = new System.Windows.Forms.Label();
            labelResult = new System.Windows.Forms.Label();
            menuStripWarehouseProducts.SuspendLayout();
            SuspendLayout();

            menuStripWarehouseProducts.BackColor = System.Drawing.Color.White;
            menuStripWarehouseProducts.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStripWarehouseProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                filterToolStripMenuItemFilter,
                createShipmentToolStripMenuItem,
                принятьПоставкуToolStripMenuItem,
                toolStripMenuItemCurrency,
                exitToolStripMenuItemOutput,
                сменитьАккаунтToolStripMenuItem
            });
            menuStripWarehouseProducts.Location = new System.Drawing.Point(0, 0);
            menuStripWarehouseProducts.Name = "menuStripWarehouseProducts";
            menuStripWarehouseProducts.Size = new System.Drawing.Size(1100, 28);
            menuStripWarehouseProducts.TabIndex = 1;

            filterToolStripMenuItemFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                весьСкладToolStripMenuItem,
                категорииToolStripMenuItem
            });
            filterToolStripMenuItemFilter.Name = "filterToolStripMenuItemFilter";
            filterToolStripMenuItemFilter.Text = "Фильтр";

            весьСкладToolStripMenuItem.Name = "весьСкладToolStripMenuItem";
            весьСкладToolStripMenuItem.Text = "Весь склад";

            категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            категорииToolStripMenuItem.Text = "Категории";

            createShipmentToolStripMenuItem.Name = "createShipmentToolStripMenuItem";
            createShipmentToolStripMenuItem.Text = "Создать отгрузку";

            принятьПоставкуToolStripMenuItem.Name = "принятьПоставкуToolStripMenuItem";
            принятьПоставкуToolStripMenuItem.Text = "Принять поставку";
            принятьПоставкуToolStripMenuItem.Click += принятьПоставкуToolStripMenuItem_Click;

            toolStripMenuItemCurrency.Name = "toolStripMenuItemCurrency";
            toolStripMenuItemCurrency.Text = "Настроить валюту";
            toolStripMenuItemCurrency.Click += buttonCurrencySettings_Click;

            exitToolStripMenuItemOutput.Name = "exitToolStripMenuItemOutput";
            exitToolStripMenuItemOutput.Text = "Выход";

            сменитьАккаунтToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";

            labelLogin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelLogin.Location = new System.Drawing.Point(820, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.TabIndex = 2;
            labelLogin.Text = "Логин:";

            labelwarehouse.AutoSize = true;
            labelwarehouse.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelwarehouse.Location = new System.Drawing.Point(20, 42);
            labelwarehouse.Name = "labelwarehouse";
            labelwarehouse.TabIndex = 0;
            labelwarehouse.Text = "Склад:";

            labelResult.AutoSize = true;
            labelResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            labelResult.Location = new System.Drawing.Point(20, 680);
            labelResult.Name = "labelResult";
            labelResult.TabIndex = 8;
            labelResult.Text = "";

            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(1100, 760);
            Controls.Add(labelResult);
            Controls.Add(labelLogin);
            Controls.Add(labelwarehouse);
            Controls.Add(menuStripWarehouseProducts);
            MainMenuStrip = menuStripWarehouseProducts;
            Name = "WarehouseStorekeeper";
            Text = "Склад кладовщика";
            menuStripWarehouseProducts.ResumeLayout(false);
            menuStripWarehouseProducts.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}