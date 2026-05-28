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

            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(120, 30);
            labelTitle.Text = "Оформление страховки";

            labelSelect.AutoSize = true;
            labelSelect.Font = new Font("Segoe UI", 12F);
            labelSelect.Location = new Point(30, 90);
            labelSelect.Text = "Выберите отгрузку:";

            comboBoxShipments.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShipments.Font = new Font("Segoe UI", 11F);
            comboBoxShipments.Location = new Point(30, 125);
            comboBoxShipments.Size = new Size(440, 38);

            buttonApply.BackColor = Color.SteelBlue;
            buttonApply.FlatStyle = FlatStyle.Flat;
            buttonApply.FlatAppearance.BorderSize = 0;
            buttonApply.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonApply.ForeColor = Color.White;
            buttonApply.Location = new Point(30, 190);
            buttonApply.Size = new Size(200, 45);
            buttonApply.Text = "Оформить страховку";

            backButton.BackColor = Color.White;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderColor = Color.SteelBlue;
            backButton.Font = new Font("Segoe UI", 12F);
            backButton.ForeColor = Color.SteelBlue;
            backButton.Location = new Point(270, 190);
            backButton.Size = new Size(200, 45);
            backButton.Text = "Назад";

            BackColor = Color.LightBlue;
            ClientSize = new Size(500, 280);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Controls.Add(backButton);
            Controls.Add(buttonApply);
            Controls.Add(comboBoxShipments);
            Controls.Add(labelSelect);
            Controls.Add(labelTitle);
            Name = "InsuranceForm";
            Text = "Страховка";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}