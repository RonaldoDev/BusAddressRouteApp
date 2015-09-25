using BusAdressRouteApp.Interfaces;
using BusAdressRouteApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BusAddressRouteApp.Models;

namespace BusAdressRouteApp.Services
{
    public class RoutesApiService : IRoutesApiService
    {
        private readonly string _baseEndPoint = @"https://api.appglu.com/v1/queries/";
        private readonly string _contentType = "application/json";
        private readonly string _customHeaderKey = "X-AppGlu-Environment";
        private readonly string _customHeaderValue = "staging";
        private readonly string _user = "WKD4N7YMA1uiM8V";
        private readonly string _password = "DtdTtzMLQlA0hk2C1Yi5pLyVIlAQ68";
        private HttpClient _client;

        private readonly string _badConnectionMessage = "Could not connect to the Server";

        public RoutesApiService()
        {
            _client = new HttpClient();
            string authentication = string.Format("{0}:{1}", _user, _password);
            var encodedAuthentication = Convert.ToBase64String(Encoding.UTF8.GetBytes(authentication));
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encodedAuthentication);
            _client.DefaultRequestHeaders.Add(_customHeaderKey, _customHeaderValue);
        }

        public async Task<IList<JsonRouteModelDto>> GetServerInformation(string endPointComplement, string paramkey, string paramValue)
        {
            try
            {
                string bodyParams = GetBodyParams(paramkey, paramValue);
                HttpResponseMessage response = await _client.PostAsync(new Uri(_baseEndPoint + endPointComplement), new StringContent(bodyParams, Encoding.UTF8, _contentType));

                if (response == null)
                {
                    return new List<JsonRouteModelDto> { new JsonRouteModelDto { Id = -1, NoSuccessMsg = _badConnectionMessage } };
                }

                return await HandleRequest(response);
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Ex:" + ex);
            }
            return new List<JsonRouteModelDto> { new JsonRouteModelDto { Id = -1, NoSuccessMsg = _badConnectionMessage } };
        }

        private async Task<IList<JsonRouteModelDto>> HandleRequest(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return (JsonConvert.DeserializeObject<JsonBaselDto>(responseContent, new JsonSerializerSettings())).rowsResponse;
            }
            else
            {
                return new List<JsonRouteModelDto> { new JsonRouteModelDto { Id = -1, NoSuccessMsg = response.ReasonPhrase } };
            }
        }

        private string GetBodyParams(string paramKey, string paramValue)
        {
            return Convert.ToString("{ \"params\": {\"" + paramKey + "\":\"%" + paramValue + "%\"}}"); ;
        }        
    }
}
