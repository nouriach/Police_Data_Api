using policeDataApi_Practice.Models;
using policeDataApi_Practice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public interface IStreetLevelOutcomesRepo
    {

        IEnumerable<StreetLevelOutcomesModel> GetAllStreetLevelOutcomesByLocation();

        Task<DisplayStreetCrimeOutViewModel> GetAllStreetLevelOutcomesByLocationAndTime(int crimeId, string date, string latitude, string longitude);

    }
}
