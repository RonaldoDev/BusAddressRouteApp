using BusAddressRouteApp.Models;
using BusAdressRouteApp.Interfaces;
using BusAdressRouteApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace BusAdressRouteApp.ViewModels
{
    /// <summary>
    /// The current MainViewModel belongs to 'Model > BusRoute.cs' scope.
    /// /// This name has been chosen in order to evidence that this is the Master entity. 
    /// </summary>
    public class MainViewModel
    {
        private readonly string _routesEndPoint = @"findRoutesByStopName/run";
        private readonly string _routesParamKey = "stopName";
        public string RouteParamValue { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IRoutesApiService _routeApiService;

        public ObservableCollection<BusRoute> RouteList { get; set; }

        public Command SearchRouteCommand { get; set; }
        public Command RouteTappedCommand { get; set; }

        public MainViewModel(INavigationService navigationService, IMessageService messageService, IRoutesApiService routeApiService)
        {
            _navigationService = navigationService;
            _routeApiService = routeApiService;
            _messageService = messageService;

            RouteTappedCommand = new Command<BusRoute>(RouteTapped);
            SearchRouteCommand = new Command(Search);

            string stopName = String.Empty;
            RouteList = new ObservableCollection<BusRoute>();

            //TODO: remove it!
            //Load("lauro linhares");
        }

        public void Search()
        {
            Load(RouteParamValue);
        }

        public async void Load(string RouteParamValue)
        {
            try
            {
                IList<JsonRouteModelDto> routeResultList = await _routeApiService.GetServerInformation(_routesEndPoint, _routesParamKey, RouteParamValue);

                HandleRouteList(routeResultList);               
            }
            catch (Exception ex)
            {
                await _messageService.ShowAsync("The App has stopped");
                System.Diagnostics.Debug.WriteLine("Ex:"+ ex);
            }
            
        }

        public async void HandleRouteList(IList<JsonRouteModelDto> routeResultList)
        {
            if (routeResultList.Count > 0 && string.IsNullOrEmpty(routeResultList.First().NoSuccessMsg))
            {
                foreach (var route in routeResultList)
                {
                    RouteList.Add(new BusRoute
                    {
                        Id = route.Id,
                        ShortName = route.ShortName,
                        LongName = route.LongName,
                        LastModified = route.LastModified,
                        AgencyId = route.AgencyId
                    });
                }
            }
            else if (routeResultList.Count == 1 && !string.IsNullOrEmpty(routeResultList.First().NoSuccessMsg) && routeResultList.First().Id == -1)
            {
                await _messageService.ShowAsync(routeResultList.First().NoSuccessMsg);
            }
            else if (routeResultList.Count == 0)
            {
                await _messageService.ShowAsync("Stop not found");
                routeResultList.Clear();
            }
        }

        private async void RouteTapped(BusRoute busAddressRoute)
        {
            await _navigationService.NavigateToStop(busAddressRoute);
        }
    }
}
