using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using policeDataApi_Practice.ViewModels;
using static policeDataApi_Practice.Models.StreetLevelOutcomesModel;

namespace policeDataApi_Practice.Data
{
    public class CallStreetLevelCrimesApiRepo : IStreetLevelCrimesRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        private StreetLevelCrimesModel[] _streetLevelCrimes;
        private Postcode _postcode;
        private Category[] _categories;

        // placeholder longitude and latitude, it works in postman
        private readonly string _defaultLocation = "lat=52.629729&lng=-1.131592";


        public CallStreetLevelCrimesApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocation()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?{_defaultLocation}");
            var client = _clientFactory.CreateClient("street-level-all-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);
                return _streetLevelCrimes;
            }
            else
            {
                return null;
            }
        }
        public async Task <StreetLevelCrimesModel> GetStreetLevelCrimeById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?{_defaultLocation}");
            var client = _clientFactory.CreateClient("street-level-all-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);
                foreach (var result in _streetLevelCrimes)
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
            var request = new HttpRequestMessage(HttpMethod.Get, $"{category.ToLower()}?{_defaultLocation}");
            var client = _clientFactory.CreateClient("street-level-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);

                return _streetLevelCrimes;
            }
            else
            {
                return null;
            }
        }

        public async Task<SelectStreetCrimeDateViewModel> GetAllStreetLevelCrimesByLocationAndTime(string month, string year, string postcodeOutcode, string postcodeIncode)
        {

            if (postcodeOutcode != null && postcodeIncode != null)
            {
                HttpRequestMessage postcodeRequest = new HttpRequestMessage(HttpMethod.Get, $"{postcodeOutcode}+{ postcodeIncode}");
                HttpClient postcodeClient = _clientFactory.CreateClient("lookup-postcode");
                var response = await postcodeClient.SendAsync(postcodeRequest);

                if (response.IsSuccessStatusCode)
                {
                    var dateJsonString = await response.Content.ReadAsStringAsync();
                    _postcode = System.Text.Json.JsonSerializer.Deserialize<Postcode>(dateJsonString);
                }
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"?date={year}-{month}&lat={_postcode.data.latitude}&lng={_postcode.data.longitude}");
            var client = _clientFactory.CreateClient("street-level-all-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {

                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);

                var categories = new List<string>();
                foreach (var cat in _streetLevelCrimes)
                {
                    categories.Add(cat.category);
                }
                
                SelectStreetCrimeDateViewModel viewModel = new SelectStreetCrimeDateViewModel
                {
                    Crimes = _streetLevelCrimes,
                    Postcode = _postcode,
                    Month = month,
                    Year = year,
                    CrimesLoaded = true,
                    FilteredCategories = categories.Distinct().ToList()
            };

                return viewModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndCategoryAndTime(string category, string date)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{category}?date={date}&{_defaultLocation}");
            var client = _clientFactory.CreateClient("street-level-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimesModel[]>(jsonString);

                return _streetLevelCrimes;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "?");
            var client = _clientFactory.CreateClient("lookup--crime-categories");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _categories = System.Text.Json.JsonSerializer.Deserialize<Category[]>(jsonString);
                var categoryList = _categories.ToList();
                return categoryList;
            }
            else
            {
                return null;
            }
        }
    }
}
