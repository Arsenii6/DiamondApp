using DiamonApp.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiamonApp.Forms.DifferentFunctionsForms
{
    public partial class InsuranceForm : Form
    {
        private readonly string _userLogin;
        private readonly CreatingShipmentForm _parentForm;
        private List<(Guid Id, string Display)> _shipments = new();

        public InsuranceForm(string userLogin, CreatingShipmentForm parentForm)
        {
            InitializeComponent();
            _userLogin = userLogin;
            _parentForm = parentForm;

            LoadShipments();
            buttonApply.Click += ButtonApply_Click!;
            backButton.Click += BackButton_Click!;

            Logger.UserAction(_userLogin, "Открыта форма страховки");
        }

        private void LoadShipments()
        {
            comboBoxShipments.Items.Clear();
            _shipments.Clear();

            _shipments = _parentForm.GetShipmentsForInsurance();

            foreach (var (_, display) in _shipments)
                comboBoxShipments.Items.Add(display);

            if (comboBoxShipments.Items.Count > 0)
                comboBoxShipments.SelectedIndex = 0;
            else
                MessageBox.Show("Корзина отгрузки пуста. Добавьте товары перед оформлением страховки.");
        }

        private void ButtonApply_Click(object? sender, EventArgs e)
        {
            if (comboBoxShipments.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите отгрузку из списка.");
                return;
            }

            var (id, display) = _shipments[comboBoxShipments.SelectedIndex];
            _parentForm.SetInsurance(id, display);

            Logger.UserAction(_userLogin, $"Страховка оформлена: Id={id}");
            MessageBox.Show($"Страховка оформлена для:\n{display}", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void BackButton_Click(object? sender, EventArgs e) => Close();
    }
}