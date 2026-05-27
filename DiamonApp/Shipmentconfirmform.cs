using DiamonApp.Classes;
using System.Windows.Forms;

namespace DiamonApp.forms.differentFunctionsForms
{
    /// <summary>
    /// Диалог подтверждения отгрузки товара.
    /// При нажатии "Да" вызывает ConfirmShipment() у родительской формы.
    /// </summary>
    public partial class ShipmentConfirmForm : Form
    {
        private readonly string _userLogin;
        private readonly CreatingShipmentForm _parentForm;

        public ShipmentConfirmForm(string userLogin, CreatingShipmentForm parentForm)
        {
            InitializeComponent();
            _userLogin = userLogin;
            _parentForm = parentForm;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Отгрузка подтверждена пользователем");
            _parentForm.ConfirmShipment();
            Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Отгрузка отменена пользователем");
            Close();
        }
    }
}