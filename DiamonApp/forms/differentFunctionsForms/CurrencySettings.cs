namespace DiamonApp.forms.differentFunctionsForms
{
    public partial class CurrencySettings : Form
    {
        private readonly string _userLogin;
        private readonly string[] _currencyCodes = { "RUB", "USD", "EUR" };
        private readonly string[] _currencyNames = { "Рубли (RUB)", "Доллары (USD)", "Евро (EUR)" };
        public CurrencySettings(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;
            comboBoxCurrency.Items.AddRange(_currencyNames);

            int idx = Array.IndexOf(_currencyCodes, AppCurrencyManager.CurrencyCode);
            comboBoxCurrency.SelectedIndex = idx >= 0 ? idx : 0;
            labelRate.Text = AppCurrencyManager.RateText;

            buttonUpdate.Click += async (s, e) => await UpdateRateAsync();
            backToolStripMenuItem.Click += BackToolStripMenuItem_Click;

            Logger.UserAction(_userLogin, "Открыта форма настройки валюты");
        }
        private async Task UpdateRateAsync()
        {
            if (comboBoxCurrency.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите валюту из списка.");
                return;
            }
            string selectedCode = _currencyCodes[comboBoxCurrency.SelectedIndex];
            buttonUpdate.Enabled = false;
            labelRate.Text = "Загрузка...";
            try
            {
                var (rate, rateText) = await AppCurrencyManager.FetchRateAsync(selectedCode);
                AppCurrencyManager.Update(selectedCode, rate, rateText);
                labelRate.Text = rateText;
                Logger.UserAction(_userLogin, $"Валюта обновлена: {selectedCode}, курс: {rateText}");
                MessageBox.Show(Resources.Success);
            }
            catch (Exception ex)
            {
                labelRate.Text = "Ошибка получения курса";
                Logger.UserAction(_userLogin, $"Ошибка при получении курса: {ex.Message}");
                MessageBox.Show($"Не удалось получить курс: {ex.Message}");
            }
            finally
            {
                buttonUpdate.Enabled = true;
            }
        }
        private void BackToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Возврат из настроек валюты");
            Close();
        }
    }
}