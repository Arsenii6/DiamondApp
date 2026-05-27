namespace DiamonApp.forms.differentFunctionsForms
{
    partial class InsuranceForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelShipmentName;
        private System.Windows.Forms.ComboBox comboBoxShipments;
        private System.Windows.Forms.Label labelInsurance;
        private System.Windows.Forms.TextBox textBoxInsurance;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelTitle = new System.Windows.Forms.Label();
            labelShipmentName = new System.Windows.Forms.Label();
            comboBoxShipments = new System.Windows.Forms.ComboBox();
            labelInsurance = new System.Windows.Forms.Label();
            textBoxInsurance = new System.Windows.Forms.TextBox();
            buttonApply = new System.Windows.Forms.Button();
            buttonBack = new System.Windows.Forms.Button();
            SuspendLayout();

            // ── Заголовок ─────────────────────────────────────────────────
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(170, 50);
            labelTitle.Name = "labelTitle";
            labelTitle.Text = "Страховка";

            // ── Название (выпадающий список отгрузок) ─────────────────────
            labelShipmentName.AutoSize = true;
            labelShipmentName.Font = new System.Drawing.Font("Segoe UI", 14F);
            labelShipmentName.Location = new System.Drawing.Point(40, 180);
            labelShipmentName.Name = "labelShipmentName";
            labelShipmentName.Text = "Название:";

            comboBoxShipments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxShipments.Font = new System.Drawing.Font("Segoe UI", 13F);
            comboBoxShipments.FormattingEnabled = true;
            comboBoxShipments.Location = new System.Drawing.Point(180, 176);
            comboBoxShipments.Name = "comboBoxShipments";
            comboBoxShipments.Size = new System.Drawing.Size(300, 36);

            // ── Страховка ─────────────────────────────────────────────────
            labelInsurance.AutoSize = true;
            labelInsurance.Font = new System.Drawing.Font("Segoe UI", 14F);
            labelInsurance.Location = new System.Drawing.Point(40, 260);
            labelInsurance.Name = "labelInsurance";
            labelInsurance.Text = "Страховка:";
            labelInsurance.Visible = false;   // скрыт — поле страховки убрано из макета

            textBoxInsurance.Font = new System.Drawing.Font("Segoe UI", 13F);
            textBoxInsurance.Location = new System.Drawing.Point(180, 256);
            textBoxInsurance.Name = "textBoxInsurance";
            textBoxInsurance.Size = new System.Drawing.Size(300, 36);
            textBoxInsurance.Visible = false;

            // ── Кнопка Оформить ───────────────────────────────────────────
            buttonApply.BackColor = System.Drawing.Color.White;
            buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonApply.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            buttonApply.FlatAppearance.BorderSize = 1;
            buttonApply.Font = new System.Drawing.Font("Segoe UI", 16F);
            buttonApply.Location = new System.Drawing.Point(140, 310);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new System.Drawing.Size(220, 60);
            buttonApply.Text = "Оформить";
            buttonApply.UseVisualStyleBackColor = false;

            // ── Кнопка Назад ──────────────────────────────────────────────
            buttonBack.BackColor = System.Drawing.Color.Transparent;
            buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            buttonBack.ForeColor = System.Drawing.Color.DimGray;
            buttonBack.Location = new System.Drawing.Point(10, 5);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new System.Drawing.Size(80, 28);
            buttonBack.Text = "← Назад";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += BackButton_Click;

            // ── Form ──────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(500, 420);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Controls.Add(buttonBack);
            Controls.Add(buttonApply);
            Controls.Add(textBoxInsurance);
            Controls.Add(labelInsurance);
            Controls.Add(comboBoxShipments);
            Controls.Add(labelShipmentName);
            Controls.Add(labelTitle);
            Name = "InsuranceForm";
            Text = "Страховка";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}