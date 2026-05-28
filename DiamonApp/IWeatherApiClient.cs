using System.Threading.Tasks;

namespace DiamonApp.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<(double temperature, double windSpeed, int humidity)> GetCurrentWeatherAsync(double lat, double lon);
        Task<string> GetWeatherDescriptionAsync(double lat, double lon);
    }
}