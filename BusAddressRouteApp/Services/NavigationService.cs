using BusAddressRouteApp.Views;
using BusAdressRouteApp.Interfaces;
using System.Threading.Tasks;
using BusAdressRouteApp.Models;

namespace BusAdressRouteApp.Services
{
    public class NavigationService: INavigationService
    {
        public async Task NavigateToMain()
        {
            await BusAddressRouteApp.App.Current.MainPage.Navigation.PushAsync(new MainView());
        }

        public async Task NavigateToStop(BusRoute busRoute)
        {
            await BusAddressRouteApp.App.Current.MainPage.Navigation.PushAsync(new BusStopView(busRoute));
        }

        public async Task NavigateToDeparture(BusStop busStop)
        {
            await BusAddressRouteApp.App.Current.MainPage.Navigation.PushAsync(new MainView());
        }

        public NavigationService()
        {

        }
    }
}
