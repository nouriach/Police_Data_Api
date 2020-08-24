using policeDataApi_Practice.Models;
using policeDataApi_Practice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public class CallNeighbourhoodApiRepo : IYourNeighbourhoodRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        private Postcode _postcode;

        public CallNeighbourhoodApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public async Task<DisplayLocalNeighbourhoodViewModel> GetNeighbourhoodLocation(string postcodeIncode, string postcodeOutcode)
        {
            var reqPostcode = new HttpRequestMessage(HttpMethod.Get, $"{ postcodeIncode}+{postcodeOutcode}");
            var client = _clientFactory.CreateClient("lookup-postcode");
            HttpResponseMessage resp = await client.SendAsync(reqPostcode);

            if (resp.IsSuccessStatusCode)
            {
                var dateJsonString = await resp.Content.ReadAsStringAsync();
                _postcode = System.Text.Json.JsonSerializer.Deserialize<Postcode>(dateJsonString);

                return null;
            }

            else
            {
                return null;
            }
        }
    }
}
