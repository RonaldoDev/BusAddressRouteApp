using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusAddressRouteApp.Models
{
    /// <summary>
    /// Data transfer Object that manipulates Json from the Rest Api
    /// </summary>
    public class JsonRouteModelDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        #region Json Routes

        [JsonProperty("shortName")]
        public string ShortName { get; set; }


        [JsonProperty("longName")]
        public string LongName { get; set; }


        [JsonProperty("lastModifiedDate")]
        public DateTime LastModified { get; set; }

        [JsonProperty("agencyId")]
        public int AgencyId { get; set; }

        #endregion

       #region Stop

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }
        
        [JsonProperty("route_id")]
        public int RouteId { get; set; }

        #endregion

        #region Departure
        [JsonProperty("calendar")]
        public string Calendar { get; set; }
        
        [JsonProperty("time")]
        public string Time { get; set; }
        #endregion

        /// <summary>
        /// This property used to capture messages returned from the server on failing cases
        /// </summary>
        public string NoSuccessMsg { get; set; }


    }    
}
