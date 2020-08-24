using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public interface IStreetLevelOutcomesRepo
    {

        IEnumerable<StreetLevelOutcomesModel> GetAllStreetLevelOutcomesByLocation();

        IEnumerable<StreetLevelOutcomesModel> GetAllStreetLevelOutcomesByLocationAndTime();


    }
}
