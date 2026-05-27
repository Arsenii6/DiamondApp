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
        private System.Windows.Forms.Label labelLogin;
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
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            BackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            insuranceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            weatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            сменитьАккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            labelLogin = new System.Windows.Forms.Label();
            labelCreatingShipment = new System.Windows.Forms.Label();
            labelBusket = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();
            comboBoxName = new System.Windows.Forms.ComboBox();
            labelUniteOfMeasure = new System.Windows.Forms.Label();
            comboBoxUniteOfMeasure = new System.Windows.Forms.ComboBox();
            labelCount = new System.Windows.Forms.Label();
            numCount = new System.Windows.Forms.NumericUpDown();
            labelSumProduct = new System.Windows.Forms.Label();
            numSumProduct = new System.Windows.Forms.NumericUpDown();
            labelRegion = new System.Windows.Forms.Label();
            comboBoxRegion = new System.Windows.Forms.ComboBox();
            labelCustomerPlace = new System.Windows.Forms.Label();
            comboBoxCustomerPlace = new System.Windows.Forms.ComboBox();
            labelCustomerName = new System.Windows.Forms.Label();
            comboBoxCustomerName = new System.Windows.Forms.ComboBox();
            buttonVerify = new System.Windows.Forms.Button();
            buttonShipment = new System.Windows.Forms.Button();
            buttonAddToBusket = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSumProduct).BeginInit();
            SuspendLayout();

            // ── MenuStrip ─────────────────────────────────────────────────
            menuStrip1.BackColor = System.Drawing.Color.White;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                BackToolStripMenuItem,
                insuranceToolStripMenuItem,
                weatherToolStripMenuItem,
                сменитьАккаунтToolStripMenuItem,
            });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1600, 28);

            BackToolStripMenuItem.Name = "BackToolStripMenuItem";
            BackToolStripMenuItem.Text = "Назад";
            BackToolStripMenuItem.Click += BackToolStripMenuItem_Click;

            insuranceToolStripMenuItem.Name = "insuranceToolStripMenuItem";
            insuranceToolStripMenuItem.Text = "Оформить страховку";

            weatherToolStripMenuItem.Name = "weatherToolStripMenuItem";
            weatherToolStripMenuItem.Text = "Загрузка погоды";
            weatherToolStripMenuItem.Click += weatherToolStripMenuItem_Click;

            сменитьАккаунтToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            сменитьАккаунтToolStripMenuItem.Name = "сменитьАккаунтToolStripMenuItem";
            сменитьАккаунтToolStripMenuItem.Text = "Сменить аккаунт";
            сменитьАккаунтToolStripMenuItem.Click += сменитьАккаунтToolStripMenuItem_Click;

            // ── Логин ─────────────────────────────────────────────────────
            labelLogin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelLogin.AutoSize = true;
            labelLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            labelLogin.Location = new System.Drawing.Point(1200, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Text = "Логин:";

            // ── Заголовок левой зоны ──────────────────────────────────────
            labelCreatingShipment.AutoSize = true;
            labelCreatingShipment.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelCreatingShipment.Location = new System.Drawing.Point(30, 38);
            labelCreatingShipment.Name = "labelCreatingShipment";
            labelCreatingShipment.Text = "Создать отгрузку";

            // ── Заголовок правой зоны ─────────────────────────────────────
            labelBusket.AutoSize = true;
            labelBusket.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelBusket.Location = new System.Drawing.Point(620, 38);
            labelBusket.Name = "labelBusket";
            labelBusket.Text = "Список";

            // ═════════════════════════════════════════════════════════════
            // ЛЕВАЯ ЗОНА: лейбл x=30, контрол x=210, ширина=350
            //             правый край контрола: 210+350 = 560
            // ПРАВАЯ ЗОНА: таблица x=600, ширина=980 (600+980=1580)
            // Зазор между зонами: 600-560 = 40px — гарантированно не перекрываются
            // ═════════════════════════════════════════════════════════════

            int lx = 30;    // x лейбла
            int cx = 210;   // x контрола
            int cw = 350;   // ширина контрола → правый край = 210+350 = 560
            int ch = 32;    // высота контрола
            int sy = 80;    // стартовый Y первого поля
            int dy = 62;    // шаг Y между полями

            // Название
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelName.Location = new System.Drawing.Point(lx, sy + 4);
            labelName.Text = "Название:";
            comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxName.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBoxName.FormattingEnabled = true;
            comboBoxName.Location = new System.Drawing.Point(cx, sy);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new System.Drawing.Size(cw, ch);
            sy += dy;

            // Ед. измерения
            labelUniteOfMeasure.AutoSize = true;
            labelUniteOfMeasure.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelUniteOfMeasure.Location = new System.Drawing.Point(lx, sy + 4);
            labelUniteOfMeasure.Text = "Ед. измерения:";
            comboBoxUniteOfMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxUniteOfMeasure.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBoxUniteOfMeasure.FormattingEnabled = true;
            comboBoxUniteOfMeasure.Location = new System.Drawing.Point(cx, sy);
            comboBoxUniteOfMeasure.Name = "comboBoxUniteOfMeasure";
            comboBoxUniteOfMeasure.Size = new System.Drawing.Size(cw, ch);
            sy += dy;

            // Количество
            labelCount.AutoSize = true;
            labelCount.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelCount.Location = new System.Drawing.Point(lx, sy + 4);
            labelCount.Text = "Количество:";
            numCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            numCount.Location = new System.Drawing.Point(cx, sy);
            numCount.Name = "numCount";
            numCount.Size = new System.Drawing.Size(cw, ch);
            numCount.Minimum = 0;
            numCount.Maximum = 99999;
            sy += dy;

            // Сумма
            labelSumProduct.AutoSize = true;
            labelSumProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelSumProduct.Location = new System.Drawing.Point(lx, sy + 4);
            labelSumProduct.Name = "labelSumProduct";
            labelSumProduct.Text = "Сумма:";
            numSumProduct.Font = new System.Drawing.Font("Segoe UI", 11F);
            numSumProduct.Location = new System.Drawing.Point(cx, sy);
            numSumProduct.Name = "numSumProduct";
            numSumProduct.Size = new System.Drawing.Size(cw, ch);
            numSumProduct.Maximum = 99999999;
            sy += dy;

            // Регион
            labelRegion.AutoSize = true;
            labelRegion.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelRegion.Location = new System.Drawing.Point(lx, sy + 4);
            labelRegion.Text = "Регион:";
            comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxRegion.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBoxRegion.Items.AddRange(new object[] { "Москва", "Санкт-Петербург", "Новосибирск" });
            comboBoxRegion.Location = new System.Drawing.Point(cx, sy);
            comboBoxRegion.Name = "comboBoxRegion";
            comboBoxRegion.Size = new System.Drawing.Size(cw, ch);
            sy += dy;

            // Куда
            labelCustomerPlace.AutoSize = true;
            labelCustomerPlace.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelCustomerPlace.Location = new System.Drawing.Point(lx, sy + 4);
            labelCustomerPlace.Text = "Куда:";
            comboBoxCustomerPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            comboBoxCustomerPlace.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBoxCustomerPlace.FormattingEnabled = true;
            comboBoxCustomerPlace.Location = new System.Drawing.Point(cx, sy);
            comboBoxCustomerPlace.Name = "comboBoxCustomerPlace";
            comboBoxCustomerPlace.Size = new System.Drawing.Size(cw, ch);

            // Скрытые контролы
            labelCustomerName.Visible = false;
            labelCustomerName.Name = "labelCustomerName";
            comboBoxCustomerName.Visible = false;
            comboBoxCustomerName.Name = "comboBoxCustomerName";
            comboBoxCustomerName.Location = new System.Drawing.Point(cx, 4);
            comboBoxCustomerName.Size = new System.Drawing.Size(cw, ch);

            // ── Кнопки ────────────────────────────────────────────────────
            // sy сейчас = Y после поля "Куда"
            int btnY = sy + dy + 10;

            // Проверить — левая зона
            buttonVerify.BackColor = System.Drawing.Color.White;
            buttonVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonVerify.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            buttonVerify.Font = new System.Drawing.Font("Segoe UI", 13F);
            buttonVerify.Location = new System.Drawing.Point(30, btnY);
            buttonVerify.Name = "buttonVerify";
            buttonVerify.Size = new System.Drawing.Size(230, 52);
            buttonVerify.Text = "Проверить";
            buttonVerify.UseVisualStyleBackColor = false;
            buttonVerify.Click += buttonVerify_Click;

            // Добавить в список — правая зона, над Отгрузить
            buttonAddToBusket.BackColor = System.Drawing.Color.SteelBlue;
            buttonAddToBusket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAddToBusket.FlatAppearance.BorderSize = 0;
            buttonAddToBusket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            buttonAddToBusket.ForeColor = System.Drawing.Color.White;
            buttonAddToBusket.Location = new System.Drawing.Point(760, btnY - 60);
            buttonAddToBusket.Name = "buttonAddToBusket";
            buttonAddToBusket.Size = new System.Drawing.Size(280, 46);
            buttonAddToBusket.Text = "Добавить в список";
            buttonAddToBusket.UseVisualStyleBackColor = false;
            buttonAddToBusket.Click += buttonAddToBusket_Click;

            // Отгрузить — правая зона
            buttonShipment.BackColor = System.Drawing.Color.White;
            buttonShipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonShipment.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            buttonShipment.Font = new System.Drawing.Font("Segoe UI", 13F);
            buttonShipment.Location = new System.Drawing.Point(900, btnY);
            buttonShipment.Name = "buttonShipment";
            buttonShipment.Size = new System.Drawing.Size(230, 52);
            buttonShipment.Text = "Отгрузить";
            buttonShipment.UseVisualStyleBackColor = false;
            buttonShipment.Click += buttonShipment_Click;

            // ── Form ──────────────────────────────────────────────────────
            int formH = btnY + 72;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(1600, formH);
            MinimumSize = new System.Drawing.Size(1600, formH + 40);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "CreatingShipmentForm";
            Text = "Создать отгрузку";
            Controls.Add(buttonAddToBusket);
            Controls.Add(buttonShipment);
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
            Controls.Add(labelLogin);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSumProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}