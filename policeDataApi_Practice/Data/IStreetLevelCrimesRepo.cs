using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public interface IStreetLevelCrimesRepo
    {
        // In here we will need (all GET commands):

        /*
            1. GetAllStreetLevelCrimes();
            2. GetStreetLevelCrimeByCrimeId();

        MAYBE
            
            3. GetAllStreetLevelCrimesByLocation()
            4. GetAllStreetLevelCrimesByMonth()
            5. GetAllStreetLevelCrimesByCategory
         */

        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocation();
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndTime(string date);
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndCategory(string category);
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndCategoryAndTime(string category, string date);
        Task<StreetLevelCrimesModel> GetStreetLevelCrimeById(int id);

    }
}
