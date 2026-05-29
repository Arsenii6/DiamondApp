namespace DiamonApp.Forms.DifferentFunctionsForms
{
    partial class InsuranceForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxShipments;
        private Button buttonApply;
        private Button backButton;
        private Label labelTitle;
        private Label labelSelect;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            comboBoxShipments = new ComboBox();
            buttonApply = new Button();
            backButton = new Button();
            labelTitle = new Label();
            labelSelect = new Label();
            SuspendLayout();
            // 
            // comboBoxShipments
            // 
            comboBoxShipments.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShipments.Font = new Font("Segoe UI", 11F);
            comboBoxShipments.Location = new Point(30, 125);
            comboBoxShipments.Name = "comboBoxShipments";
            comboBoxShipments.Size = new Size(440, 38);
            comboBoxShipments.TabIndex = 2;
            // 
            // buttonApply
            // 
            buttonApply.BackColor = Color.SteelBlue;
            buttonApply.FlatAppearance.BorderSize = 0;
            buttonApply.FlatStyle = FlatStyle.Flat;
            buttonApply.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonApply.ForeColor = Color.White;
            buttonApply.Location = new Point(30, 190);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(200, 45);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "Оформить страховку";
            buttonApply.UseVisualStyleBackColor = false;
            // 
            // backButton
            // 
            backButton.BackColor = Color.White;
            backButton.FlatAppearance.BorderColor = Color.SteelBlue;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 12F);
            backButton.ForeColor = Color.SteelBlue;
            backButton.Location = new Point(270, 190);
            backButton.Name = "backButton";
            backButton.Size = new Size(200, 45);
            backButton.TabIndex = 0;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(28, 30);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(442, 48);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Оформление страховки";
            // 
            // labelSelect
            // 
            labelSelect.AutoSize = true;
            labelSelect.Font = new Font("Segoe UI", 12F);
            labelSelect.Location = new Point(30, 90);
            labelSelect.Name = "labelSelect";
            labelSelect.Size = new Size(229, 32);
            labelSelect.TabIndex = 3;
            labelSelect.Text = "Выберите отгрузку:";
            // 
            // InsuranceForm
            // 
            BackColor = Color.LightBlue;
            ClientSize = new Size(500, 280);
            Controls.Add(backButton);
            Controls.Add(buttonApply);
            Controls.Add(comboBoxShipments);
            Controls.Add(labelSelect);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "InsuranceForm";
            Text = "Страховка";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}