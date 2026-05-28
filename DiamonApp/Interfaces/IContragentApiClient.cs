using System.Threading.Tasks;

namespace DiamondApp.Interfaces
{
    public interface IContragentApiClient
    {
        Task<(string name, string details)> FindByInnAsync(string inn);
    }
}