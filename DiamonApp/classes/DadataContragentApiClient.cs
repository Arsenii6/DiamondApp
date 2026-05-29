using DiamondApp.Interfaces;
using Newtonsoft.Json.Linq;
namespace DiamondApp.classes
{
    public class DadataContragentApiClient : IContragentApiClient
    {
        private const string DadataToken = "f96e0e4ba6dfb43f6db60146a3d763662836ba85";
        private const string DadataSecret = "46b253686b7b7d1d9d49822806db6dfff9c4bf2d";
        public async Task<(string name, string details)> FindByInnAsync(string inn)
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.Add("Authorization", $"Token {DadataToken}");
            client.DefaultRequestHeaders.Add("X-Secret", DadataSecret);
            var body = JsonConvert.SerializeObject(new { query = inn });
            var content = new StringContent(body, Encoding.UTF8);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(
                "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party",
                content);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);
            var suggestions = obj["suggestions"];
            if (suggestions == null || !suggestions.HasValues)
                return ("", "Контрагент с таким ИНН не найден.");

            var data = suggestions[0]["data"];
            string name = suggestions[0]["value"]?.ToString() ?? "";
            string inn_ = data?["inn"]?.ToString() ?? "—";
            string ogrn = data?["ogrn"]?.ToString() ?? "—";
            string kpp = data?["kpp"]?.ToString() ?? "—";
            string addr = data?["address"]?["value"]?.ToString() ?? "—";
            string stat = data?["state"]?["status"]?.ToString() ?? "—";
            string opf = data?["opf"]?["short"]?.ToString() ?? "—";
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
    }
}