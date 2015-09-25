using Xamarin.Forms;

namespace BusAddressRouteApp
{
    public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new Views.MainView());
		}
	}
}

