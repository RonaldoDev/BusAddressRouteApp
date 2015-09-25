using BusAdressRouteApp.ViewModels;
using Newtonsoft.Json;
using System;

namespace BusAdressRouteApp.Models
{
    public class BusDeparture : BaseViewModel
    {
        public BusDeparture()
        {
        }

        private int _id;
        private string _calendar;
        private string _time;


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

        public string Calendar
        {
            get
            {
                return _calendar;
            }
            set
            {
                _calendar = value;
                this.Notity("Calendar");
            }
        }
    }
}
