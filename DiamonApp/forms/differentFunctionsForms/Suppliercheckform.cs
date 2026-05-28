using Newtonsoft.Json.Linq;
namespace DiamondApp.forms.differentFunctionsForms
{
    public partial class SupplierCheckForm : Form
    {
        private readonly string _userLogin;
        private readonly AcceptanceOfGoodsForm _parentForm;
        private string _foundName = "";
        private string _foundInn = "";
        private const string DadataToken = "f96e0e4ba6dfb43f6db60146a3d763662836ba85";
        private const string DadataSecret = "46b253686b7b7d1d9d49822806db6dfff9c4bf2d";
        public SupplierCheckForm(string userLogin, AcceptanceOfGoodsForm parentForm)
        {
            InitializeComponent();
            _userLogin = userLogin;
            _parentForm = parentForm;

            textBoxInn.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) await buttonSearchClickAsync();
            };

            buttonSearch.Click += async (s, e) => await buttonSearchClickAsync();
            buttonYes.Click += buttonYes_Click;
            buttonNo.Click += buttonNo_Click;
            backToolStripMenuItem.Click += (s, e) => Close();
        }
        private async Task buttonSearchClickAsync()
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
                var (name, details) = await FindByInnAsync(inn);
                _foundName = name;
                _foundInn = inn;
                richTextBoxInfo.Text = details;
                buttonYes.Enabled = !string.IsNullOrEmpty(name);
                Logger.UserAction(_userLogin, $"Проверка ИНН {inn}: найдено '{name}'");
            }
            catch (HttpRequestException ex)
            {
                richTextBoxInfo.Text = $"Ошибка сети: {ex.Message}\n\nПроверьте подключение к интернету.";
                Logger.UserAction(_userLogin, $"Ошибка сети при проверке ИНН {inn}: {ex.Message}");
            }
            catch (Exception ex)
            {
                richTextBoxInfo.Text = $"Ошибка: {ex.Message}\n\nВозможно, превышен лимит запросов к API.";
                Logger.UserAction(_userLogin, $"Ошибка проверки ИНН {inn}: {ex.Message}");
            }
            finally
            {
                buttonSearch.Enabled = true;
            }
        }
        private async Task<(string name, string details)> FindByInnAsync(string inn)
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(15);
            client.DefaultRequestHeaders.Add("Authorization", $"Token {DadataToken}");
            client.DefaultRequestHeaders.Add("X-Secret", DadataSecret);

            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new { query = inn });
            var content = new StringContent(body, Encoding.UTF8);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party",
                content);
            string json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return ("", "Ошибка авторизации API. Проверьте токен DaData.");
                }
                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    return ("", "Превышен лимит запросов к API. Попробуйте позже.");
                }
                return ("", $"Ошибка API: {response.StatusCode}\n{json}");
            }
            var obj = JObject.Parse(json);
            var suggestions = obj["suggestions"];

            if (suggestions == null || !suggestions.HasValues)
                return ("", "Контрагент с таким ИНН не найден.");
            var data = suggestions[0]?["data"];
            var address = data?["address"];
            var state = data?["state"];
            var opf = data?["opf"];
            string name = suggestions[0]?["value"]?.ToString() ?? "";
            string inn_ = data?["inn"]?.ToString() ?? "—";
            string ogrn = data?["ogrn"]?.ToString() ?? "—";
            string kpp = data?["kpp"]?.ToString() ?? "—";
            string addr = address?["value"]?.ToString() ?? "—";
            string stat = state?["status"]?.ToString() ?? "—";
            string opfShort = opf?["short"]?.ToString() ?? "—";
            string details =
                $"Наименование: {name}\n" +
                $"ОПФ:          {opfShort}\n" +
                $"ИНН:          {inn_}\n" +
                $"ОГРН:         {ogrn}\n" +
                $"КПП:          {kpp}\n" +
                $"Статус:       {stat}\n" +
                $"Адрес:        {addr}";

            return (name, details);
        }
        private void buttonYes_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_foundName))
            {
                MessageBox.Show("Сначала найдите контрагента по ИНН.");
                return;
            }

            Logger.UserAction(_userLogin, $"Поставщик подтверждён: {_foundName} (ИНН {_foundInn})");
            _parentForm.SetSupplierFromApi(_foundName, _foundInn);
            Close();
        }
        private void buttonNo_Click(object? sender, EventArgs e)
        {
            Logger.UserAction(_userLogin, "Проверка по API отменена");
            Close();
        }
    }
}