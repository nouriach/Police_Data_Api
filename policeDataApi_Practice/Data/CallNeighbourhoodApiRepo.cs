using policeDataApi_Practice.Models;
using policeDataApi_Practice.Models.NeighbourhoodModels;
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
        private LocateNeighbourhood _lostcateNeighbourhood;
        private NeighbourhoodTeam[] _neighbourhoodTeam;

        public CallNeighbourhoodApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public async Task<DisplayLocalNeighbourhoodViewModel> GetNeighbourhoodLocation(string postcodeIncode, string postcodeOutcode)
        {
            if (postcodeOutcode != null && postcodeIncode != null)
            {
                var reqPostcode = new HttpRequestMessage(HttpMethod.Get, $"{ postcodeIncode}+{postcodeOutcode}");
                var client = _clientFactory.CreateClient("lookup-postcode");
                HttpResponseMessage resp = await client.SendAsync(reqPostcode);

                if (resp.IsSuccessStatusCode)
                {
                    var dateJsonString = await resp.Content.ReadAsStringAsync();
                    _postcode = System.Text.Json.JsonSerializer.Deserialize<Postcode>(dateJsonString);
                }
            }

            var requestNeighbourhood = new HttpRequestMessage(HttpMethod.Get, $"locate-neighbourhood?q={_postcode.data.latitude},{_postcode.data.longitude}");
            var clientNeighbourhood = _clientFactory.CreateClient("base-police-api-call");
            HttpResponseMessage respNeighbourhood = await clientNeighbourhood.SendAsync(requestNeighbourhood);

            if (respNeighbourhood.IsSuccessStatusCode)
            {
                var neighbourhoodJsonString = await respNeighbourhood.Content.ReadAsStringAsync();
                _lostcateNeighbourhood = System.Text.Json.JsonSerializer.Deserialize<LocateNeighbourhood>(neighbourhoodJsonString);

                var viewModel = new DisplayLocalNeighbourhoodViewModel
                {
                    LocateNeighbourhood = _lostcateNeighbourhood,
                    NeighbourhoodLoaded = postcodeIncode != null ? true : false
                };

            return viewModel;
;
            }
            else
            {
                return null;
            }
        }

        public async Task<NeighbourhoodTeam[]> GetNeighbourhoodTeam(string location, string force)
        {
            if (location != null && force != null)
            {
                var req = new HttpRequestMessage(HttpMethod.Get, $"{location}/{force}/people");
                var client = _clientFactory.CreateClient("base-police-api-call");
                HttpResponseMessage resp = await client.SendAsync(req);

                if (resp.IsSuccessStatusCode)
                {
                    var jsonString = await resp.Content.ReadAsStringAsync();
                    _neighbourhoodTeam = System.Text.Json.JsonSerializer.Deserialize<NeighbourhoodTeam[]>(jsonString);
                    return _neighbourhoodTeam;
                }

                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
