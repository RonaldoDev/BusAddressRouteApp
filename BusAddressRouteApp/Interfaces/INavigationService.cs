using BusAdressRouteApp.Models;
using System.Threading.Tasks;

namespace BusAdressRouteApp.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToMain();

        Task NavigateToStop(BusRoute busRoute);
        
        Task NavigateToDeparture(BusStop busStop);
    }
}
