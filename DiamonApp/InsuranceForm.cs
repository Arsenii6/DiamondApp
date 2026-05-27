using DiamonApp.Classes;
using DiamondApp.Resourses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiamonApp.forms.differentFunctionsForms
{
    /// <summary>
    /// Форма оформления страховки.
    /// Список строк корзины получает из родительской формы через GetShipmentsForInsurance().
    /// Страховка привязывается к конкретной строке по Id записи в БД.
    /// </summary>
    public partial class InsuranceForm : Form
    {
        private readonly string _userLogin;
        private readonly CreatingShipmentForm _parentForm;

        // Id записи из БД → отображаемое название
        private List<(Guid Id, string Display)> _shipments = new();

        public InsuranceForm(string userLogin, CreatingShipmentForm parentForm)
        {
            InitializeComponent();
            _userLogin = userLogin;
            _parentForm = parentForm;

            LoadShipments();
            buttonApply.Click += ButtonApply_Click;

            Logger.UserAction(_userLogin, "Открыта форма страховки");
        }

        private void LoadShipments()
        {
            comboBoxShipments.Items.Clear();
            _shipments.Clear();

            // Получаем актуальный список из родительской формы вместе с Id
            _shipments = _parentForm.GetShipmentsForInsurance();

            foreach (var (_, display) in _shipments)
                comboBoxShipments.Items.Add(display);

            if (comboBoxShipments.Items.Count > 0)
                comboBoxShipments.SelectedIndex = 0;
            else
                MessageBox.Show("Корзина отгрузки пуста. Добавьте товары перед оформлением страховки.");
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (comboBoxShipments.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите отгрузку из списка.");
                return;
            }

            var (id, display) = _shipments[comboBoxShipments.SelectedIndex];
            string insuranceName = display; // страховка = отображаемое имя строки

            // Передаём Id — страховка точно привяжется к нужной строке
            _parentForm.SetInsurance(id, insuranceName);

            Logger.UserAction(_userLogin, $"Страховка оформлена: Id={id}");
            MessageBox.Show($"Страховка оформлена для:\n{display}", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void BackButton_Click(object sender, EventArgs e) => Close();
    }
}