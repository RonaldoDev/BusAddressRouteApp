using BusAddressRouteApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusAdressRouteApp.Interfaces
{
    public interface IRoutesApiService
    {
        Task<IList<JsonRouteModelDto>> GetServerInformation(string endPointComplement, string paramkey, string paramValue);
    }
}
