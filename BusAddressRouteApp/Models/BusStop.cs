using BusAdressRouteApp.ViewModels;
using Newtonsoft.Json;
using System;

namespace BusAdressRouteApp.Models
{
    public class BusStop : BaseViewModel
    {
        public BusStop()
        {
        }

        private int _id;
        private string _name;
        private string _sequence;
        private int _routeId;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                this.Notity("Id");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.Notity("Name");
            }
        }

        public string Sequence
        {
            get
            {
                return _sequence;
            }
            set
            {
                _sequence = value;
                this.Notity("Sequence");
            }
        }

        public int RouteId
        {
            get
            {
                return _routeId;
            }
            set
            {
                _routeId = value;
                this.Notity("RouteId");
            }
        }

    }
}
