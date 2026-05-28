namespace DiamonApp.forms.differentFunctionsForms
{
    public partial class ShipmentCheckForm : Form
    {
        private readonly string _userLogin;
        private readonly CreatingShipmentForm _parentForm;
        private string _foundName = "";
        private string _foundInn = "";
        private const string DadataToken = "f96e0e4ba6dfb43f6db60146a3d763662836ba85";
        private const string DadataSecret = "46b253686b7b7d1d9d49822806db6dfff9c4bf2d";
        public ShipmentCheckForm(string userLogin, CreatingShipmentForm parentForm)
        {
            InitializeComponent();
            _userLogin = userLogin;
            _parentForm = parentForm;

            textBoxInn.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) buttonSearch_Click(s, e);
            };
        }
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string inn = textBoxInn.Text.Trim();

            if (string.IsNullOrWhiteSpace(inn) || (inn.Length != 10 && inn.Length != 12))
            {
                MessageBox.Show("Введите корректный ИНН (10 или 12 цифр).");
                return;
            }
            buttonSearch.Enabled = false;
            richTextBoxInfo.Text = "Загрузка...";
            buttonYes.Enabled = false;
            _foundName = "";
            _foundInn = "";
            try
            {
                (string name, string details) = await FindByInnAsync(inn);
                _foundName = name;
                _foundInn = inn;
                richTextBoxInfo.Text = details;
                buttonYes.Enabled = !string.IsNullOrEmpty(name);
                Logger.UserAction(_userLogin, $"Проверка ИНН {inn}: найдено '{name}'");
            }
            catch (Exception ex)
            {
                richTextBoxInfo.Text = $"Ошибка при запросе к API:\n{ex.Message}";
                Logger.UserAction(_userLogin, $"Ошибка проверки ИНН {inn}: {ex.Message}");
            }
            finally
            {
                buttonSearch.Enabled = true;
            }
        }
        private static async Task<(string name, string details)> FindByInnAsync(string inn)
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.Add("Authorization", $"Token {DadataToken}");
            client.DefaultRequestHeaders.Add("X-Secret", DadataSecret);
            var body = System.Text.Json.JsonSerializer.Serialize(new { query = inn });
            var content = new StringContent(body, Encoding.UTF8);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(
                "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party",
                content);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var suggestions = doc.RootElement.GetProperty("suggestions");

            if (suggestions.GetArrayLength() == 0)
                return ("", "Контрагент с таким ИНН не найден.");

            var data = suggestions[0].GetProperty("data");
            string name = suggestions[0].GetProperty("value").GetString() ?? "";
            string inn_ = TryGet(data, "inn");
            string ogrn = TryGet(data, "ogrn");
            string kpp = TryGet(data, "kpp");
            string addr = TryGet(data.GetProperty("address"), "value");
            string stat = TryGet(data.GetProperty("state"), "status");
            string opf = TryGet(data.GetProperty("opf"), "short");
            string details =
                $"Наименование: {name}\n" +
                $"ОПФ:          {opf}\n" +
                $"ИНН:          {inn_}\n" +
                $"ОГРН:         {ogrn}\n" +
                $"КПП:          {kpp}\n" +
                $"Статус:       {stat}\n" +
                $"Адрес:        {addr}";

            return (name, details);
        }
        private static string TryGet(JsonElement element, string key)
        {
            try { return element.GetProperty(key).GetString() ?? "—"; }
            catch { return "—"; }
        }
        private void buttonYes_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, $"Контрагент подтверждён: {_foundName} (ИНН {_foundInn})");
            _parentForm.SetCustomerFromApi(_foundName, _foundInn);
            Close();
        }
        private void buttonNo_Click(object sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Проверка по API отменена");
            Close();
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    }
}