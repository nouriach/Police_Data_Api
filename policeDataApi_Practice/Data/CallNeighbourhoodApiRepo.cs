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
        private LocateNeighbourhood _locateNeighbourhood;
        private NeighbourhoodTeam[] _neighbourhoodTeam;
        private LocateSpecificNeighbourhood _neighbourhoodDetails;
        private NeighbourhoodPriorities[] _neighbourhoodPriorities;

        public CallNeighbourhoodApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public async Task<NeighbourhoodPriorities[]> GetNeighbourhoodPriorities(string location, string force)
        {
            if (location != null && force != null)
            {
                var req = new HttpRequestMessage(HttpMethod.Get, $"{location}/{force}/priorities");
                var client = _clientFactory.CreateClient("base-police-api-call");
                HttpResponseMessage resp = await client.SendAsync(req);

                if (resp.IsSuccessStatusCode)
                {
                    var jsonString = await resp.Content.ReadAsStringAsync();
                    _neighbourhoodPriorities = System.Text.Json.JsonSerializer.Deserialize<NeighbourhoodPriorities[]>(jsonString);
                    return _neighbourhoodPriorities;
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<LocateSpecificNeighbourhood> GetNeighbourhoodDetails(string location, string force)
        {
            if (location != null && force != null)
            {
                var req = new HttpRequestMessage(HttpMethod.Get, $"{location}/{force}");
                var client = _clientFactory.CreateClient("base-police-api-call");
                HttpResponseMessage resp = await client.SendAsync(req);

                if (resp.IsSuccessStatusCode)
                {
                    var jsonString = await resp.Content.ReadAsStringAsync();
                    _neighbourhoodDetails = System.Text.Json.JsonSerializer.Deserialize<LocateSpecificNeighbourhood>(jsonString);
                    return _neighbourhoodDetails;
                }

                return null;
            }
            else
            {
                return null;
            }
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
                _locateNeighbourhood = System.Text.Json.JsonSerializer.Deserialize<LocateNeighbourhood>(neighbourhoodJsonString);

                var viewModel = new DisplayLocalNeighbourhoodViewModel
                {
                    LocateNeighbourhood = _locateNeighbourhood,
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
