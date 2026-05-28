using DiamonApp.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiamonApp.Services
{
    public class OpenMeteoWeatherApiClient : IWeatherApiClient
    {
        public async Task<(double temperature, double windSpeed, int humidity)> GetCurrentWeatherAsync(double lat, double lon)
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);

            string url = $"https://api.open-meteo.com/v1/forecast" +
                         $"?latitude={lat.ToString(CultureInfo.InvariantCulture)}" +
                         $"&longitude={lon.ToString(CultureInfo.InvariantCulture)}" +
                         $"&current=temperature_2m,wind_speed_10m,relative_humidity_2m" +
                         $"&timezone=auto";

            string json = await client.GetStringAsync(url);
            using var doc = JsonDocument.Parse(json);
            var current = doc.RootElement.GetProperty("current");

            double temp = current.GetProperty("temperature_2m").GetDouble();
            double wind = current.GetProperty("wind_speed_10m").GetDouble();
            int humidity = current.GetProperty("relative_humidity_2m").GetInt32();

            return (temp, wind, humidity);
        }

        public async Task<string> GetWeatherDescriptionAsync(double lat, double lon)
        {
            var (temp, wind, humidity) = await GetCurrentWeatherAsync(lat, lon);
            return $"{temp:F0}°C, ветер {wind:F0} м/с, влажность {humidity}%";
        }
    }
}