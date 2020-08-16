using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public interface IStreetLevelCrimesRepo
    {
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocation();
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndTime(string date);
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndCategory(string category);
        Task<StreetLevelCrimesModel[]> GetAllStreetLevelCrimesByLocationAndCategoryAndTime(string category, string date);
        Task<StreetLevelCrimesModel> GetStreetLevelCrimeById(int id);
    }
}
