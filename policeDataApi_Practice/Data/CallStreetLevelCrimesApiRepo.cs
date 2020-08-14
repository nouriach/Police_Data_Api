using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public class CallStreetLevelCrimesApiRepo : IStreetLevelCrimesRepo
    {
        public IEnumerable<StreetLevelCrimesModel> GetAllStreetLevelCrimesByLocation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StreetLevelCrimesModel> GetAllStreetLevelCrimesByLocationAndCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StreetLevelCrimesModel> GetAllStreetLevelCrimesByLocationAndTime()
        {
            throw new NotImplementedException();
        }

        public StreetLevelCrimesModel GetStreetLevelCrimeById()
        {
            throw new NotImplementedException();
        }
    }
}
