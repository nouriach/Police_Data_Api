using policeDataApi_Practice.Models;
using policeDataApi_Practice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public class CallStreetLevelOutcomesApiRepo : IStreetLevelOutcomesRepo
    {
        private IHttpClientFactory _clientFactory;
        private StreetLevelOutcomesModel[] _streetLevelCrimesOutcomes;
        public CallStreetLevelOutcomesApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<DisplayStreetCrimeOutViewModel> GetAllStreetLevelOutcomesByLocationAndTime(int crimeId, string date, string latitude, string longitude)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?date={date}&lat={latitude}&lng={longitude}");

            var client = _clientFactory.CreateClient("street-level-outcomes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimesOutcomes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelOutcomesModel[]>(jsonString);
                var list = _streetLevelCrimesOutcomes.ToList();
                var result = list.Where(x => x.crime.id.ToString() == crimeId.ToString()).FirstOrDefault();

                var viewModel = new DisplayStreetCrimeOutViewModel
                {
                    CrimeOutcomeLoaded = result == null ? false : true,
                    StreetLevelCrimeOutcome = result
                };

                return viewModel;
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<StreetLevelOutcomesModel> GetAllStreetLevelOutcomesByLocation()
        {
            throw new NotImplementedException();
        }
    }
}
