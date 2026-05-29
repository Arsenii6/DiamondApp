namespace Draft_Diamond_BD
{
    partial class WarehouseAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelwarehouse;
        private System.Windows.Forms.MenuStrip menuStripWarehouseProducts;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem addCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem changeCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCategoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteCategoryToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItemFilter;
        private System.Windows.Forms.ToolStripMenuItem весьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCollections;
        private System.Windows.Forms.ToolStripMenuItem принятьПоставкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCurrency;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemOutput;
        private System.Windows.Forms.ToolStripMenuItem changeAccountToolStripMenuItem;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button buttonHistoryShipment;
        private System.Windows.Forms.Button buttonWrittenOff;
        private System.Windows.Forms.Label labelResult;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            labelwarehouse = new Label();
            menuStripWarehouseProducts = new MenuStrip();
            toolStripMenuItem3 = new ToolStripMenuItem();
            addCardToolStripMenuItem = new ToolStripMenuItem();
            NewCategoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            changeCardToolStripMenuItem = new ToolStripMenuItem();
            changeCategoryToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            deleteCardToolStripMenuItem = new ToolStripMenuItem();
            DeleteCategoryToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItemSearch = new ToolStripMenuItem();
            filterToolStripMenuItemFilter = new ToolStripMenuItem();
            весьСкладToolStripMenuItem = new ToolStripMenuItem();
            категорииToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemCollections = new ToolStripMenuItem();
            принятьПоставкуToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemCurrency = new ToolStripMenuItem();
            exitToolStripMenuItemOutput = new ToolStripMenuItem();
            changeAccountToolStripMenuItem = new ToolStripMenuItem();
            labelLogin = new Label();
            buttonHistoryShipment = new Button();
            buttonWrittenOff = new Button();
            labelResult = new Label();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            menuStripWarehouseProducts.SuspendLayout();
            SuspendLayout();
            // 
            // labelwarehouse
            // 
            labelwarehouse.AutoSize = true;
            labelwarehouse.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelwarehouse.Location = new Point(20, 42);
            labelwarehouse.Name = "labelwarehouse";
            labelwarehouse.Size = new Size(136, 48);
            labelwarehouse.TabIndex = 0;
            labelwarehouse.Text = "Склад:";
            // 
            // menuStripWarehouseProducts
            // 
            menuStripWarehouseProducts.BackColor = Color.White;
            menuStripWarehouseProducts.ImageScalingSize = new Size(20, 20);
            menuStripWarehouseProducts.Items.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem2, toolStripMenuItem1, toolStripMenuItemSearch, filterToolStripMenuItemFilter, toolStripMenuItemCollections, принятьПоставкуToolStripMenuItem, toolStripMenuItemCurrency, exitToolStripMenuItemOutput, changeAccountToolStripMenuItem });
            menuStripWarehouseProducts.Location = new Point(0, 0);
            menuStripWarehouseProducts.Name = "menuStripWarehouseProducts";
            menuStripWarehouseProducts.Size = new Size(1341, 33);
            menuStripWarehouseProducts.TabIndex = 1;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { addCardToolStripMenuItem, NewCategoryToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(106, 29);
            toolStripMenuItem3.Text = "Добавить";
            // 
            // addCardToolStripMenuItem
            // 
            addCardToolStripMenuItem.Name = "addCardToolStripMenuItem";
            addCardToolStripMenuItem.Size = new Size(203, 34);
            addCardToolStripMenuItem.Text = "Карточку";
            addCardToolStripMenuItem.Click += new EventHandler(AddCardToolStripMenuItem_Click);  // ДОБАВЛЕНО!
            // 
            // NewCategoryToolStripMenuItem
            // 
            NewCategoryToolStripMenuItem.Name = "NewCategoryToolStripMenuItem";
            NewCategoryToolStripMenuItem.Size = new Size(203, 34);
            NewCategoryToolStripMenuItem.Text = "Категорию";
            NewCategoryToolStripMenuItem.Click += newCategoryToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { changeCardToolStripMenuItem, changeCategoryToolStripMenuItem1 });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(107, 29);
            toolStripMenuItem2.Text = "Изменить";
            // 
            // changeCardToolStripMenuItem
            // 
            changeCardToolStripMenuItem.Name = "changeCardToolStripMenuItem";
            changeCardToolStripMenuItem.Size = new Size(203, 34);
            changeCardToolStripMenuItem.Text = "Карточку";
            changeCardToolStripMenuItem.Click += changeCardToolStripMenuItem_Click;
            // 
            // changeCategoryToolStripMenuItem1
            // 
            changeCategoryToolStripMenuItem1.Name = "changeCategoryToolStripMenuItem1";
            changeCategoryToolStripMenuItem1.Size = new Size(203, 34);
            changeCategoryToolStripMenuItem1.Text = "Категорию";
            changeCategoryToolStripMenuItem1.Click += CategoryChangeToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { deleteCardToolStripMenuItem, DeleteCategoryToolStripMenuItem2 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(92, 29);
            toolStripMenuItem1.Text = "Удалить";
            // 
            // deleteCardToolStripMenuItem
            // 
            deleteCardToolStripMenuItem.Name = "deleteCardToolStripMenuItem";
            deleteCardToolStripMenuItem.Size = new Size(203, 34);
            deleteCardToolStripMenuItem.Text = "Карточку";
            deleteCardToolStripMenuItem.Click += deleteCardToolStripMenuItem_Click;
            // 
            // DeleteCategoryToolStripMenuItem2
            // 
            DeleteCategoryToolStripMenuItem2.Name = "DeleteCategoryToolStripMenuItem2";
            DeleteCategoryToolStripMenuItem2.Size = new Size(203, 34);
            DeleteCategoryToolStripMenuItem2.Text = "Категорию";
            DeleteCategoryToolStripMenuItem2.Click += deleteCategoryToolStripMenuItem2_Click;
            // 
            // toolStripMenuItemSearch
            // 
            toolStripMenuItemSearch.Name = "toolStripMenuItemSearch";
            toolStripMenuItemSearch.Size = new Size(79, 29);
            toolStripMenuItemSearch.Text = "Поиск";
            // 
            // filterToolStripMenuItemFilter
            // 
            filterToolStripMenuItemFilter.DropDownItems.AddRange(new ToolStripItem[] { весьСкладToolStripMenuItem, категорииToolStripMenuItem });
            filterToolStripMenuItemFilter.Name = "filterToolStripMenuItemFilter";
            filterToolStripMenuItemFilter.Size = new Size(87, 29);
            filterToolStripMenuItemFilter.Text = "Фильтр";
            // 
            // весьСкладToolStripMenuItem
            // 
            весьСкладToolStripMenuItem.Name = "весьСкладToolStripMenuItem";
            весьСкладToolStripMenuItem.Size = new Size(200, 34);
            весьСкладToolStripMenuItem.Text = "Весь склад";
            // 
            // категорииToolStripMenuItem
            // 
            категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            категорииToolStripMenuItem.Size = new Size(200, 34);
            категорииToolStripMenuItem.Text = "Категории";
            // 
            // toolStripMenuItemCollections
            // 
            toolStripMenuItemCollections.Name = "toolStripMenuItemCollections";
            toolStripMenuItemCollections.Size = new Size(116, 29);
            toolStripMenuItemCollections.Text = "Коллекции";
            toolStripMenuItemCollections.Click += toolStripMenuItemCollections_Click;
            // 
            // принятьПоставкуToolStripMenuItem
            // 
            принятьПоставкуToolStripMenuItem.Name = "принятьПоставкуToolStripMenuItem";
            принятьПоставкуToolStripMenuItem.Size = new Size(175, 29);
            принятьПоставкуToolStripMenuItem.Text = "Принять поставку";
            принятьПоставкуToolStripMenuItem.Click += принятьПоставкуToolStripMenuItem_Click;
            // 
            // toolStripMenuItemCurrency
            // 
            toolStripMenuItemCurrency.Name = "toolStripMenuItemCurrency";
            toolStripMenuItemCurrency.Size = new Size(177, 29);
            toolStripMenuItemCurrency.Text = "Настроить валюту";
            toolStripMenuItemCurrency.Click += toolStripMenuItemCurrency_Click;
            // 
            // exitToolStripMenuItemOutput
            // 
            exitToolStripMenuItemOutput.Name = "exitToolStripMenuItemOutput";
            exitToolStripMenuItemOutput.Size = new Size(80, 29);
            exitToolStripMenuItemOutput.Text = "Выход";
            // 
            // changeAccountToolStripMenuItem
            // 
            changeAccountToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            changeAccountToolStripMenuItem.Name = "changeAccountToolStripMenuItem";
            changeAccountToolStripMenuItem.Size = new Size(164, 29);
            changeAccountToolStripMenuItem.Text = "Сменить аккаунт";
            changeAccountToolStripMenuItem.Click += changeAccountToolStripMenuItem_Click;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 11F);
            labelLogin.Location = new Point(1061, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(80, 30);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "Логин:";
            // 
            // buttonHistoryShipment
            // 
            buttonHistoryShipment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHistoryShipment.BackColor = Color.White;
            buttonHistoryShipment.FlatAppearance.BorderColor = Color.LightGray;
            buttonHistoryShipment.FlatStyle = FlatStyle.Flat;
            buttonHistoryShipment.Font = new Font("Segoe UI", 11F);
            buttonHistoryShipment.Location = new Point(1061, 38);
            buttonHistoryShipment.Name = "buttonHistoryShipment";
            buttonHistoryShipment.Size = new Size(260, 38);
            buttonHistoryShipment.TabIndex = 4;
            buttonHistoryShipment.Text = "История отгрузок";
            buttonHistoryShipment.UseVisualStyleBackColor = false;
            buttonHistoryShipment.Click += buttonHistoryShipment_Click;
            // 
            // buttonWrittenOff
            // 
            buttonWrittenOff.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonWrittenOff.BackColor = Color.Crimson;
            buttonWrittenOff.FlatAppearance.BorderSize = 0;
            buttonWrittenOff.FlatStyle = FlatStyle.Flat;
            buttonWrittenOff.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            buttonWrittenOff.ForeColor = Color.White;
            buttonWrittenOff.Location = new Point(12, 669);
            buttonWrittenOff.Name = "buttonWrittenOff";
            buttonWrittenOff.Size = new Size(340, 55);
            buttonWrittenOff.TabIndex = 5;
            buttonWrittenOff.Text = "Склад списанных товаров";
            buttonWrittenOff.UseVisualStyleBackColor = false;
            buttonWrittenOff.Click += buttonWrittenOff_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 10F);
            labelResult.Location = new Point(20, 650);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 28);
            labelResult.TabIndex = 6;
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = UpdateRowSource.None;
            // 
            // WarehouseAdmin
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(1341, 760);
            Controls.Add(labelResult);
            Controls.Add(buttonWrittenOff);
            Controls.Add(buttonHistoryShipment);
            Controls.Add(labelLogin);
            Controls.Add(labelwarehouse);
            Controls.Add(menuStripWarehouseProducts);
            MainMenuStrip = menuStripWarehouseProducts;
            Name = "WarehouseAdmin";
            Text = "Склад администратора";
            menuStripWarehouseProducts.ResumeLayout(false);
            menuStripWarehouseProducts.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}