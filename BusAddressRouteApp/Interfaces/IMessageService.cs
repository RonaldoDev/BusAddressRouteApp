using System.Threading.Tasks;

namespace BusAdressRouteApp.Interfaces
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
