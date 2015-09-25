using BusAdressRouteApp.Interfaces;
using System.Threading.Tasks;

namespace BusAdressRouteApp.Services
{
    public class MessageService: IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await BusAddressRouteApp.App.Current.MainPage.DisplayAlert("Transport Routes App", message, "ok");            
        }
    }
}
