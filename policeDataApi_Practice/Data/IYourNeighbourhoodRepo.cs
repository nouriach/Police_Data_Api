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
    }
}
