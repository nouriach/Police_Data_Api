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
        private IHttpClientFactory _clientFactory;
        public CallNeighbourhoodApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public Task<DisplayLocalNeighbourhoodViewModel> GetNeighbourhoodLocation()
        {
            throw new NotImplementedException();
        }
    }
}
