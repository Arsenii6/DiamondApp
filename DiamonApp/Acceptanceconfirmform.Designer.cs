namespace DiamondApp.forms.differentFunctionsForms
{
    partial class AcceptanceConfirmForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelQuestion = new System.Windows.Forms.Label();
            buttonYes = new System.Windows.Forms.Button();
            buttonNo = new System.Windows.Forms.Button();
            SuspendLayout();

            // Вопрос
            labelQuestion.AutoSize = false;
            labelQuestion.Font = new System.Drawing.Font("Segoe UI", 14F);
            labelQuestion.ForeColor = System.Drawing.Color.DarkBlue;
            labelQuestion.Location = new System.Drawing.Point(30, 40);
            labelQuestion.Size = new System.Drawing.Size(540, 60);
            labelQuestion.Text = "Вы уверены, что хотите добавить данную поставку?";
            labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Кнопка Да
            buttonYes.BackColor = System.Drawing.Color.LightGreen;
            buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonYes.FlatAppearance.BorderSize = 0;
            buttonYes.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            buttonYes.Location = new System.Drawing.Point(60, 125);
            buttonYes.Size = new System.Drawing.Size(180, 60);
            buttonYes.Name = "buttonYes";
            buttonYes.Text = "Да";
            buttonYes.Click += buttonYes_Click;

            // Кнопка Нет
            buttonNo.BackColor = System.Drawing.Color.IndianRed;
            buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonNo.FlatAppearance.BorderSize = 0;
            buttonNo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            buttonNo.ForeColor = System.Drawing.Color.White;
            buttonNo.Location = new System.Drawing.Point(360, 125);
            buttonNo.Size = new System.Drawing.Size(180, 60);
            buttonNo.Name = "buttonNo";
            buttonNo.Text = "Нет";
            buttonNo.Click += buttonNo_Click;

            // Form
            BackColor = System.Drawing.Color.LightBlue;
            ClientSize = new System.Drawing.Size(600, 220);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(labelQuestion);
            Name = "AcceptanceConfirmForm";
            Text = "Подтверждение приёмки";
            ResumeLayout(false);
        }
    }
}