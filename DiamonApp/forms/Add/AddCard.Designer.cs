namespace Draft_Diamond_BD
{
    partial class AddCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelAddCard = new Label();
            labelNameCard = new Label();
            labelUnit = new Label();
            textBoxName = new TextBox();
            buttonAdd = new Button();
            comboBoxUniteOfMeasure = new ComboBox();
            comboBoxCategory = new ComboBox();
            CategoryLabel = new Label();
            menuStrip1 = new MenuStrip();
            назадToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();

            // menuStrip
            menuStrip1.BackColor = System.Drawing.Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { назадToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(500, 28);
            menuStrip1.TabIndex = 12;

            назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            назадToolStripMenuItem.Size = new Size(65, 24);
            назадToolStripMenuItem.Text = "Назад";
            назадToolStripMenuItem.Click += BackToolStripMenuItem_Click;

            // Заголовок
            labelAddCard.Anchor = AnchorStyles.Top;
            labelAddCard.AutoSize = true;
            labelAddCard.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelAddCard.Location = new Point(110, 42);
            labelAddCard.Name = "labelAddCard";
            labelAddCard.TabIndex = 0;
            labelAddCard.Text = "Добавить карточку";

            // Название
            labelNameCard.AutoSize = true;
            labelNameCard.Font = new Font("Segoe UI", 12F);
            labelNameCard.Location = new Point(50, 108);
            labelNameCard.Name = "labelNameCard";
            labelNameCard.TabIndex = 1;
            labelNameCard.Text = "Название:";

            textBoxName.BackColor = System.Drawing.Color.White;
            textBoxName.Font = new Font("Segoe UI", 12F);
            textBoxName.ForeColor = System.Drawing.Color.Black;
            textBoxName.Location = new Point(50, 133);
            textBoxName.Margin = new Padding(3, 4, 3, 4);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(390, 32);
            textBoxName.TabIndex = 4;

            // Единица измерения
            labelUnit.AutoSize = true;
            labelUnit.Font = new Font("Segoe UI", 12F);
            labelUnit.Location = new Point(50, 188);
            labelUnit.Name = "labelUnit";
            labelUnit.TabIndex = 2;
            labelUnit.Text = "Единица измерения:";

            comboBoxUniteOfMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUniteOfMeasure.FlatStyle = FlatStyle.Flat;
            comboBoxUniteOfMeasure.Font = new Font("Segoe UI", 12F);
            comboBoxUniteOfMeasure.FormattingEnabled = true;
            comboBoxUniteOfMeasure.Location = new Point(50, 213);
            comboBoxUniteOfMeasure.Margin = new Padding(3, 4, 3, 4);
            comboBoxUniteOfMeasure.Name = "comboBoxUniteOfMeasure";
            comboBoxUniteOfMeasure.Size = new Size(390, 30);
            comboBoxUniteOfMeasure.TabIndex = 8;

            // Категория
            CategoryLabel.AutoSize = true;
            CategoryLabel.Font = new Font("Segoe UI", 12F);
            CategoryLabel.Location = new Point(50, 268);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.TabIndex = 10;
            CategoryLabel.Text = "Категория:";

            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.FlatStyle = FlatStyle.Flat;
            comboBoxCategory.Font = new Font("Segoe UI", 12F);
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(50, 293);
            comboBoxCategory.Margin = new Padding(3, 4, 3, 4);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(390, 30);
            comboBoxCategory.TabIndex = 11;

            // Кнопка Добавить
            buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            buttonAdd.ForeColor = System.Drawing.Color.White;
            buttonAdd.Location = new Point(145, 360);
            buttonAdd.Margin = new Padding(3, 4, 3, 4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(210, 48);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new Size(500, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Controls.Add(comboBoxCategory);
            Controls.Add(CategoryLabel);
            Controls.Add(comboBoxUniteOfMeasure);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxName);
            Controls.Add(labelUnit);
            Controls.Add(labelNameCard);
            Controls.Add(labelAddCard);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddCard";
            Text = "Добавить карточку";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelAddCard;
        private Label labelNameCard;
        private Label labelUnit;
        private TextBox textBoxName;
        private Button buttonAdd;
        private ComboBox comboBoxUniteOfMeasure;
        private ComboBox comboBoxCategory;
        private Label CategoryLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem назадToolStripMenuItem;
    }
}