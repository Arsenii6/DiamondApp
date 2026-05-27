using System;
using System.IO;
using System.Windows.Forms;

namespace DiamonApp.Classes
{
    public static class AppCurrencyManager
    {
        private static readonly string SettingsFile = Path.Combine(
            Application.StartupPath, "currency_settings.txt");

        public static string CurrencyCode { get; private set; } = "RUB";
        public static string CurrencySymbol { get; private set; } = "₽";
        public static double RateToRub { get; private set; } = 1.0;
        public static string RateText { get; private set; } = "1 RUB = 1.00 RUB";

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

        private static void Save()
        {
            try
            {
                File.WriteAllLines(SettingsFile, new[]
                {
                    CurrencyCode,
                    RateToRub.ToString(System.Globalization.CultureInfo.InvariantCulture),
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
                RateToRub = double.Parse(lines[1].Trim(), System.Globalization.CultureInfo.InvariantCulture);
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