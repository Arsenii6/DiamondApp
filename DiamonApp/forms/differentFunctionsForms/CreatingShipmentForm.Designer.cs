namespace DiamonApp.forms.differentFunctionsForms
{
    partial class CreatingShipmentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insuranceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weatherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьАккаунтToolStripMenuItem;
        private System.Windows.Forms.Label labelCreatingShipment;
        private System.Windows.Forms.Label labelBusket;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label labelUniteOfMeasure;
        private System.Windows.Forms.ComboBox comboBoxUniteOfMeasure;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Label labelSumProduct;
        private System.Windows.Forms.NumericUpDown numSumProduct;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label labelCustomerPlace;
        private System.Windows.Forms.ComboBox comboBoxCustomerPlace;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.ComboBox comboBoxCustomerName;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.Button buttonShipment;
        private System.Windows.Forms.Button buttonAddToBusket;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            BackToolStripMenuItem = new ToolStripMenuItem();
            insuranceToolStripMenuItem = new ToolStripMenuItem();
            weatherToolStripMenuItem = new ToolStripMenuItem();
            сменитьАккаунтToolStripMenuItem = new ToolStripMenuItem();
            labelCreatingShipment = new Label();
            labelBusket = new Label();
            labelName = new Label();
            comboBoxName = new ComboBox();
            labelUniteOfMeasure = new Label();
            comboBoxUniteOfMeasure = new ComboBox();
            labelCount = new Label();
            numCount = new NumericUpDown();
            labelSumProduct = new Label();
            numSumProduct = new NumericUpDown();
            labelRegion = new Label();
            comboBoxRegion = new ComboBox();
            labelCustomerPlace = new Label();
            comboBoxCustomerPlace = new ComboBox();
            labelCustomerName = new Label();
            comboBoxCustomerName = new ComboBox();
            buttonVerify = new Button();
            buttonShipment = new Button();
            buttonAddToBusket = new Button();
            labelLogin = new Label();
            menuStrip1.SuspendLayout();
            ((ISupportInitialize)numCount).BeginInit();
            ((ISupportInitialize)numSumProduct).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { BackToolStripMenuItem, insuranceToolStripMenuItem, weatherToolStripMenuItem, сменитьАккаунтToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1773, 33);
            menuStrip1.TabIndex = 0;
            // 
            // BackToolStripMenuItem
            // 
            BackToolStripMenuItem.Name = "BackToolStripMenuItem";
            BackToolStripMenuItem.Size = new Size(77, 29);
            BackToolStripMenuItem.Text = "Назад";
            BackToolStripMenuItem.Click += BackToolStripMenuItem_Click;
            // 
            // insuranceToolStripMenuItem
            // 
            insuranceToolStripMenuItem.Name = "insuranceToolStripMenuItem";
            insuranceToolStripMenuItem.Size = new Size(202, 29);
            insuranceToolStripMenuItem.Text = "Оформить страховку";
            insuranceToolStripMenuItem.Click += InsuranceToolStripMenuItem_Click;
            // 
            // weatherToolStripMenuItem
            // 
            weatherToolStripMenuItem.Name = "weatherToolStripMenuItem";
            weatherToolStripMenuItem.Size = new Size(167, 29);
            weatherToolStripMenuItem.Text = "Загрузка погоды";
            weatherToolStripMenuItem.Click += weatherToolStripMenuItem_Click;
            // 
            // сменитьАккаунтToolStripMenuItem
            // 
            сменитьАккаунтToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Size = new Size(164, 29);
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            сменитьАккаунтToolStripMenuItem.Click += сменитьАккаунтToolStripMenuItem_Click;
            // 
            // labelCreatingShipment
            // 
            labelCreatingShipment.AutoSize = true;
            labelCreatingShipment.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelCreatingShipment.Location = new Point(30, 40);
            labelCreatingShipment.Name = "labelCreatingShipment";
            labelCreatingShipment.Size = new Size(317, 48);
            labelCreatingShipment.TabIndex = 2;
            labelCreatingShipment.Text = "Создать отгрузку";
            // 
            // labelBusket
            // 
            labelBusket.AutoSize = true;
            labelBusket.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelBusket.Location = new Point(620, 40);
            labelBusket.Name = "labelBusket";
            labelBusket.Size = new Size(146, 48);
            labelBusket.TabIndex = 3;
            labelBusket.Text = "Список";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.Location = new Point(30, 100);
            labelName.Name = "labelName";
            labelName.Size = new Size(125, 32);
            labelName.TabIndex = 4;
            labelName.Text = "Название:";
            // 
            // comboBoxName
            // 
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.Font = new Font("Segoe UI", 11F);
            comboBoxName.Location = new Point(210, 100);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(350, 38);
            comboBoxName.TabIndex = 5;
            comboBoxName.Click += comboBoxName_SelectedIndexChanged;
            // 
            // labelUniteOfMeasure
            // 
            labelUniteOfMeasure.AutoSize = true;
            labelUniteOfMeasure.Font = new Font("Segoe UI", 12F);
            labelUniteOfMeasure.Location = new Point(30, 150);
            labelUniteOfMeasure.Name = "labelUniteOfMeasure";
            labelUniteOfMeasure.Size = new Size(178, 32);
            labelUniteOfMeasure.TabIndex = 6;
            labelUniteOfMeasure.Text = "Ед. измерения:";
            // 
            // comboBoxUniteOfMeasure
            // 
            comboBoxUniteOfMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUniteOfMeasure.Font = new Font("Segoe UI", 11F);
            comboBoxUniteOfMeasure.Location = new Point(210, 150);
            comboBoxUniteOfMeasure.Name = "comboBoxUniteOfMeasure";
            comboBoxUniteOfMeasure.Size = new Size(350, 38);
            comboBoxUniteOfMeasure.TabIndex = 7;
            comboBoxUniteOfMeasure.Click += comboBoxUniteOfMeasure_SelectedIndexChanged;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Font = new Font("Segoe UI", 12F);
            labelCount.Location = new Point(30, 200);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(149, 32);
            labelCount.TabIndex = 8;
            labelCount.Text = "Количество:";
            // 
            // numCount
            // 
            numCount.Font = new Font("Segoe UI", 11F);
            numCount.Location = new Point(210, 200);
            numCount.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numCount.Name = "numCount";
            numCount.Size = new Size(350, 37);
            numCount.TabIndex = 9;
            // 
            // labelSumProduct
            // 
            labelSumProduct.AutoSize = true;
            labelSumProduct.Font = new Font("Segoe UI", 12F);
            labelSumProduct.Location = new Point(30, 250);
            labelSumProduct.Name = "labelSumProduct";
            labelSumProduct.Size = new Size(92, 32);
            labelSumProduct.TabIndex = 10;
            labelSumProduct.Text = "Сумма:";
            // 
            // numSumProduct
            // 
            numSumProduct.Font = new Font("Segoe UI", 11F);
            numSumProduct.Location = new Point(210, 250);
            numSumProduct.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numSumProduct.Name = "numSumProduct";
            numSumProduct.Size = new Size(350, 37);
            numSumProduct.TabIndex = 11;
            // 
            // labelRegion
            // 
            labelRegion.AutoSize = true;
            labelRegion.Font = new Font("Segoe UI", 12F);
            labelRegion.Location = new Point(30, 300);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(96, 32);
            labelRegion.TabIndex = 12;
            labelRegion.Text = "Регион:";
            // 
            // comboBoxRegion
            // 
            comboBoxRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRegion.Font = new Font("Segoe UI", 11F);
            comboBoxRegion.Items.AddRange(new object[] { "Москва", "Санкт-Петербург", "Новосибирск" });
            comboBoxRegion.Location = new Point(210, 300);
            comboBoxRegion.Name = "comboBoxRegion";
            comboBoxRegion.Size = new Size(350, 38);
            comboBoxRegion.TabIndex = 13;
            // 
            // labelCustomerPlace
            // 
            labelCustomerPlace.AutoSize = true;
            labelCustomerPlace.Font = new Font("Segoe UI", 12F);
            labelCustomerPlace.Location = new Point(30, 350);
            labelCustomerPlace.Name = "labelCustomerPlace";
            labelCustomerPlace.Size = new Size(70, 32);
            labelCustomerPlace.TabIndex = 14;
            labelCustomerPlace.Text = "Куда:";
            // 
            // comboBoxCustomerPlace
            // 
            comboBoxCustomerPlace.Font = new Font("Segoe UI", 11F);
            comboBoxCustomerPlace.Location = new Point(210, 350);
            comboBoxCustomerPlace.Name = "comboBoxCustomerPlace";
            comboBoxCustomerPlace.Size = new Size(350, 38);
            comboBoxCustomerPlace.TabIndex = 15;
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.Font = new Font("Segoe UI", 12F);
            labelCustomerName.Location = new Point(30, 400);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(161, 32);
            labelCustomerName.TabIndex = 21;
            labelCustomerName.Text = "Имя клиента:";
            labelCustomerName.Visible = false;
            // 
            // comboBoxCustomerName
            // 
            comboBoxCustomerName.Location = new Point(210, 400);
            comboBoxCustomerName.Name = "comboBoxCustomerName";
            comboBoxCustomerName.Size = new Size(350, 33);
            comboBoxCustomerName.TabIndex = 17;
            comboBoxCustomerName.Visible = false;
            // 
            // buttonVerify
            // 
            buttonVerify.BackColor = Color.White;
            buttonVerify.FlatAppearance.BorderColor = Color.Gray;
            buttonVerify.FlatStyle = FlatStyle.Flat;
            buttonVerify.Font = new Font("Segoe UI", 13F);
            buttonVerify.Location = new Point(80, 559);
            buttonVerify.Name = "buttonVerify";
            buttonVerify.Size = new Size(247, 52);
            buttonVerify.TabIndex = 18;
            buttonVerify.Text = "Проверить по API";
            buttonVerify.UseVisualStyleBackColor = false;
            buttonVerify.Click += buttonVerify_Click;
            // 
            // buttonShipment
            // 
            buttonShipment.BackColor = Color.White;
            buttonShipment.FlatAppearance.BorderColor = Color.Gray;
            buttonShipment.FlatStyle = FlatStyle.Flat;
            buttonShipment.Font = new Font("Segoe UI", 13F);
            buttonShipment.Location = new Point(914, 559);
            buttonShipment.Name = "buttonShipment";
            buttonShipment.Size = new Size(230, 52);
            buttonShipment.TabIndex = 20;
            buttonShipment.Text = "Отгрузить";
            buttonShipment.UseVisualStyleBackColor = false;
            buttonShipment.Click += buttonShipment_Click;
            // 
            // buttonAddToBusket
            // 
            buttonAddToBusket.BackColor = Color.SteelBlue;
            buttonAddToBusket.FlatAppearance.BorderSize = 0;
            buttonAddToBusket.FlatStyle = FlatStyle.Flat;
            buttonAddToBusket.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonAddToBusket.ForeColor = Color.White;
            buttonAddToBusket.Location = new Point(67, 481);
            buttonAddToBusket.Name = "buttonAddToBusket";
            buttonAddToBusket.Size = new Size(280, 46);
            buttonAddToBusket.TabIndex = 19;
            buttonAddToBusket.Text = "Добавить в список";
            buttonAddToBusket.UseVisualStyleBackColor = false;
            buttonAddToBusket.Click += buttonAddToBusket_Click;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 11F);
            labelLogin.Location = new Point(1622, 33);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(80, 30);
            labelLogin.TabIndex = 22;
            labelLogin.Text = "Логин:";
            // 
            // CreatingShipmentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1773, 754);
            Controls.Add(labelLogin);
            Controls.Add(buttonShipment);
            Controls.Add(buttonAddToBusket);
            Controls.Add(buttonVerify);
            Controls.Add(comboBoxCustomerName);
            Controls.Add(labelCustomerName);
            Controls.Add(comboBoxCustomerPlace);
            Controls.Add(labelCustomerPlace);
            Controls.Add(comboBoxRegion);
            Controls.Add(labelRegion);
            Controls.Add(numSumProduct);
            Controls.Add(labelSumProduct);
            Controls.Add(numCount);
            Controls.Add(labelCount);
            Controls.Add(comboBoxUniteOfMeasure);
            Controls.Add(labelUniteOfMeasure);
            Controls.Add(comboBoxName);
            Controls.Add(labelName);
            Controls.Add(labelBusket);
            Controls.Add(labelCreatingShipment);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CreatingShipmentForm";
            Text = "Создать отгрузку";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((ISupportInitialize)numCount).EndInit();
            ((ISupportInitialize)numSumProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label labelLogin;
    }
}