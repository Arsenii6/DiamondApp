using Newtonsoft.Json.Linq;
namespace DiamonApp.Classes
{
    public static class AppCurrencyManager
    {
        private static readonly string SettingsFile = Path.Combine(Application.StartupPath, "currency_settings.txt");

        public static string CurrencyCode { get; private set; } = "RUB";
        public static string CurrencySymbol { get; private set; } = "₽";
        public static double RateToRub { get; private set; } = 1.0;
        public static string RateText { get; private set; } = "1 RUB = 1.00 RUB";

        public static event EventHandler? CurrencyChanged;
        static AppCurrencyManager()
        {
            Load();
        }
        public static void Update(string code, double rateToRub, string rateText)
        {
            CurrencyCode = code;
            RateToRub = rateToRub;
            RateText = rateText;
            CurrencySymbol = code switch
            {
                "USD" => "$",
                "EUR" => "€",
                _ => "₽"
            };
            Save();
            CurrencyChanged?.Invoke(null, EventArgs.Empty);
        }
        public static decimal Convert(decimal rubAmount)
        {
            if (RateToRub <= 0) return rubAmount;
            return Math.Round(rubAmount / (decimal)RateToRub, 2);
        }
        public static string Format(decimal rubAmount)
        {
            return $"{Convert(rubAmount):F2} {CurrencySymbol}";
        }
        public static async Task<(double rate, string text)> FetchRateAsync(string currencyCode)
        {
            if (currencyCode == "RUB")
                return (1.0, "1 RUB = 1.00 RUB (базовая валюта)");

            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            string url = $"https://open.er-api.com/v6/latest/{currencyCode}";
            string response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);
            if (json["result"]?.ToString() != "success")
                throw new Exception("API вернул ошибку");

            double rubRate = json["rates"]?["RUB"]?.Value<double>() ?? 0;
            return (rubRate, $"1 {currencyCode} = {rubRate:F2} RUB");
        }
        private static void Save()
        {
            try
            {
                File.WriteAllLines(SettingsFile, new[]
                {
                    CurrencyCode,
                    RateToRub.ToString(),
                    RateText
                });
            }
            catch { }
        }
        private static void Load()
        {
            try
            {
                if (!File.Exists(SettingsFile)) return;
                string[] lines = File.ReadAllLines(SettingsFile);
                if (lines.Length < 3) return;
                CurrencyCode = lines[0].Trim();
                RateToRub = double.Parse(lines[1].Trim());
                RateText = lines[2].Trim();
                CurrencySymbol = CurrencyCode switch
                {
                    "USD" => "$",
                    "EUR" => "€",
                    _ => "₽"
                };
            }
            catch { }
        }
    }
}