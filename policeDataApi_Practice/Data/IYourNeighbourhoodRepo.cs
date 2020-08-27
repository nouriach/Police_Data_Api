using policeDataApi_Practice.Models.NeighbourhoodModels;
using policeDataApi_Practice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Data
{
    public interface IYourNeighbourhoodRepo
    {
        Task<DisplayLocalNeighbourhoodViewModel> GetNeighbourhoodLocation(string postcodeIncode, string postcodeOutcode);
        Task<NeighbourhoodTeam[]> GetNeighbourhoodTeam(string location, string force);
        Task<LocateSpecificNeighbourhood> GetNeighbourhoodDetails(string location, string force);
    }
}
