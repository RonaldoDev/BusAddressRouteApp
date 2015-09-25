using BusAddressRouteApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusAdressRouteApp.Models
{
    public class JsonBaselDto
    {
        [JsonProperty("rows")]
        public IList<JsonRouteModelDto> rowsResponse { get; set; }        
    }
   
}
