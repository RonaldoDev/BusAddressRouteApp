using BusAdressRouteApp.Models;
using BusAdressRouteApp.Services;

using Xamarin.Forms;

namespace BusAddressRouteApp.Views
{
    /// <summary>
    /// The current MainView belongs to 'Model -> BusRoute.cs' scope.
    /// This name has been chosen in order to evidence that this is the main one.
    /// </summary>
    public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
			BindingContext = new BusAdressRouteApp.ViewModels.MainViewModel(new NavigationService(), new MessageService(), new RoutesApiService());
		}

		private void RouteTapped(object sender, ItemTappedEventArgs e)
		{
			(BindingContext as BusAdressRouteApp.ViewModels.MainViewModel).RouteTappedCommand.Execute(e.Item as BusRoute);
		}
	}
}

