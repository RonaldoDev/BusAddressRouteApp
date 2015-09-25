using BusAdressRouteApp.ViewModels;
using System;

namespace BusAdressRouteApp.Models
{
    public class BusRoute: BaseViewModel
    {
        public BusRoute()
        {
        }
        
        private int _id;
        private string _shortName;
        private string _longName;

        private DateTime _lastModified;
        private int _agencyId;

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

        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
                this.Notity("ShortName");
            }
        }

        public string LongName
        {
            get
            {
                return _longName;
            }
            set
            {
                _longName = value;
                this.Notity("LongName");
            }
        }

        public DateTime LastModified
        {
            get
            {
                return _lastModified;
            }
            set
            {
                _lastModified = value;
                this.Notity("LastModified");
            }
        }

        public int AgencyId
        {
            get
            {
                return _agencyId;
            }
            set
            {
                _agencyId = value;
                this.Notity("AgencyId");
            }
        }
    }
}
