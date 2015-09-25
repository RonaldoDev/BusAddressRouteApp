using BusAddressRouteApp.Models;
using BusAdressRouteApp.Interfaces;
using BusAdressRouteApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusAdressRouteApp.ViewModels
{
    public class BusStopViewModel
    {
        private readonly string _stopEndPoint = @"findStopsByRouteId/run";
        private readonly string _stopParamKey = "routeId";

        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IRoutesApiService _routeApiService;

        public ObservableCollection<BusStop> StopList { get; set; }

        public ICommand PreviousCommand { get; set; }
        public Command StopTappedCommand { get; set; }

        public BusStopViewModel(BusRoute busAddressRoute, INavigationService navigationService, IMessageService messageService, IRoutesApiService routeApiService)
        {
            _navigationService = navigationService;
            _routeApiService = routeApiService;
            _messageService = messageService;

            PreviousCommand = new Command(Previous);
            StopTappedCommand = new Command<BusStop>(StopTapped);
            LoadRouteDetails(busAddressRoute);
        }

        public async void LoadRouteDetails(BusRoute busAddressRoute)
        {
            try
            {
                IList<JsonRouteModelDto> stopResultList = await _routeApiService.GetServerInformation(_stopEndPoint, _stopParamKey, busAddressRoute.Id.ToString());
                HandleStopList(stopResultList);                
            }

            catch (Exception ex)
            {
                await _messageService.ShowAsync("The App stopped");
                System.Diagnostics.Debug.WriteLine("Ex:" + ex);
            }

        }

        private async void HandleStopList(IList<JsonRouteModelDto> stopResultList)
        {
            if (stopResultList.Count > 0 && string.IsNullOrEmpty(stopResultList.First().NoSuccessMsg))
            {
                foreach (var stop in stopResultList)
                {
                    StopList.Add(new BusStop
                    {
                        Id = stop.Id,
                        Name = stop.Name,
                        Sequence = stop.Sequence,
                        RouteId = stop.RouteId
                    });
                }
            }            
            else if (stopResultList.Count == 1 && !string.IsNullOrEmpty(stopResultList.First().NoSuccessMsg) && stopResultList.First().Id == -1)
            {
                await _messageService.ShowAsync(stopResultList.First().NoSuccessMsg);
            }
            else if (stopResultList.Count == 0)
            {
                await _messageService.ShowAsync("Stop not found");
            }
        }

        private async void Previous()
        {
            await _navigationService.NavigateToMain();
        }

        private void StopTapped(BusStop busStop)
        {
            _navigationService.NavigateToMain();
        }
    }
}
