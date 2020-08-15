using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace policeDataApi_Practice.Data
{
    public class CallStreetLevelCrimesApiRepo : IStreetLevelCrimesRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        private StreetLevelCrimesModel[] _streetLevelCrimes;


        public CallStreetLevelCrimesApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocation()
        {
            // placeholder longitude and latitude, it works in postman
            var request = new HttpRequestMessage(HttpMethod.Get, "?lat=52.629729&lng=-1.131592");
            var client = _clientFactory.CreateClient("street-level-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                var jsonModel = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);
                return jsonModel;
            }
            else
            {
                return null;
            }
        }
        public async Task <StreetLevelCrimesModel> GetStreetLevelCrimeById(int id)
        {
            // placeholder longitude and latitude, it works in postman
            var request = new HttpRequestMessage(HttpMethod.Get, "?lat=52.629729&lng=-1.131592");
            var client = _clientFactory.CreateClient("street-level-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                var jsonModel = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);
                foreach (var result in jsonModel)
                {
                    if(result.id == id)
                    {
                        return result;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndCategory(string category)
        {
            var matchCrimesByCategory = new List<StreetLevelCrimesModel>();

            // placeholder longitude and latitude, it works in postman
            var request = new HttpRequestMessage(HttpMethod.Get, $"?{category}&lat=52.629729&lng=-1.131592");
            var client = _clientFactory.CreateClient("street-level-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                var jsonModel = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);

                foreach (var result in jsonModel)
                {
                    if (result.category.ToLower() == category.ToLower())
                    {
                        matchCrimesByCategory.Add(result);
                    }
                }

                StreetLevelCrimesModel[] finalCrimeArray = matchCrimesByCategory.ToArray();
                return finalCrimeArray;
            }
            else
            {
                return null;
            }
        }

        public Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndTime()
        {
            throw new NotImplementedException();
        }

    }
}
