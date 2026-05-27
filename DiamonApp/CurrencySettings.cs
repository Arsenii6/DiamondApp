namespace DiamonApp.forms.differentFunctionsForms
{
    /// <summary>
    /// Форма настройки валюты с получением актуального курса через API.
    /// Доступна как из формы администратора, так и из формы кладовщика.
    /// После обновления курс применяется во всех формах через AppCurrencyManager.
    /// </summary>
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

            // Восстанавливаем ранее выбранную валюту
            int idx = Array.IndexOf(_currencyCodes, AppCurrencyManager.CurrencyCode);
            comboBoxCurrency.SelectedIndex = idx >= 0 ? idx : 0;

            // Показываем текущий сохранённый курс
            labelRate.Text = AppCurrencyManager.RateText;

            buttonUpdate.Click += async (s, e) => await UpdateRateAsync();
            backToolStripMenuItem.Click += BackToolStripMenuItem_Click;

            Logger.UserAction(_userLogin, "Открыта форма настройки валюты");
        }

        /// <summary>
        /// Получает курс выбранной валюты через API и обновляет AppCurrencyManager.
        /// Все формы автоматически получат новый курс при следующей загрузке данных.
        /// </summary>
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
                (double rate, string rateText) = await FetchRateAsync(selectedCode);

                // Обновляем глобальный менеджер — курс сохраняется на диск
                // и сразу доступен всем формам через AppCurrencyManager.Format()
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

        /// <summary>
        /// Запрашивает курс валюты через бесплатный API open.er-api.com (без ключа).
        /// Возвращает курс к рублю и читаемую строку.
        /// </summary>
        private static async Task<(double rate, string text)> FetchRateAsync(string currencyCode)
        {
            if (currencyCode == "RUB")
                return (1.0, "1 RUB = 1.00 RUB (базовая валюта)");

            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);

            string url = $"https://open.er-api.com/v6/latest/{currencyCode}";
            string response = await client.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            if (root.GetProperty("result").GetString() != "success")
                throw new Exception("API вернул ошибку");

            double rubRate = root.GetProperty("rates").GetProperty("RUB").GetDouble();
            return (rubRate, $"1 {currencyCode} = {rubRate:F2} RUB");
        }

        /// <summary>
        /// Возврат: определяем роль пользователя и открываем нужную форму склада
        /// </summary>
        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Возврат из настроек валюты");
            using (var db = new AllDB())
            {
                var emp = db.Employess.FirstOrDefault(p => p.Login == _userLogin);
                if (emp != null && emp.Job == JobsEnumcs.Administrator)
                {
                    new WarehouseAdmin(_userLogin).Show();
                }
                else
                {
                    new WarehouseStorekeeper(_userLogin).Show();
                }
            }
            Hide();
        }
    }
}