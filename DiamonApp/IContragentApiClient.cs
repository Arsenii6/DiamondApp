using System.Threading.Tasks;

namespace DiamonApp.Interfaces
{
    public interface IContragentApiClient
    {
        Task<(string name, string details)> FindByInnAsync(string inn);
    }
}