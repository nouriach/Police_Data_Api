using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public class CallStreetLevelOutcomesApiRepo : IStreetLevelOutcomesRepo
    {
        public CallStreetLevelOutcomesApiRepo()
        {

        }
        public IEnumerable<StreetLevelOutcomesModel> GetAllStreetLevelOutcomesByLocation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StreetLevelOutcomesModel> GetAllStreetLevelOutcomesByLocationAndTime()
        {
            throw new NotImplementedException();
        }
    }
}
