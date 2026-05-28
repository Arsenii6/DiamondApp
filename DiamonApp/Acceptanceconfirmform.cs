using DiamonApp.Classes;
using System;
using System.Windows.Forms;

namespace DiamondApp.forms.differentFunctionsForms
{
    public partial class AcceptanceConfirmForm : Form
    {
        private readonly string _userLogin;
        private readonly AcceptanceOfGoodsForm _parentForm;

        public AcceptanceConfirmForm(string userLogin, AcceptanceOfGoodsForm parentForm)
        {
            InitializeComponent();
            _userLogin = userLogin;
            _parentForm = parentForm;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Приёмка подтверждена пользователем");
            _parentForm.ConfirmAcceptance();
            Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Приёмка отменена пользователем");
            Close();
        }
    }
}