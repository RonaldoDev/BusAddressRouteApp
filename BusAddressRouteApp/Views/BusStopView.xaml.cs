using BusAdressRouteApp.Interfaces;
using BusAdressRouteApp.Models;
using BusAdressRouteApp.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BusAddressRouteApp.Views
{
	public partial class BusStopView : ContentPage
	{
		public BusStopView (BusRoute busAddressRoute)
		{
			InitializeComponent ();
			BindingContext = new BusAdressRouteApp.ViewModels.BusStopViewModel(busAddressRoute, new NavigationService(), new MessageService(), new RoutesApiService());
		}
	}
}

