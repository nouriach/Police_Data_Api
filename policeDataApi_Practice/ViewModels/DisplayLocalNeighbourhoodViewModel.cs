using policeDataApi_Practice.Models.NeighbourhoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.ViewModels
{
    public class DisplayLocalNeighbourhoodViewModel
    {
        public LocateNeighbourhood LocateNeighbourhood { get; set; }
        public NeighbourhoodTeam[] NeighbourhoodTeam { get; set; }
        public LocateSpecificNeighbourhood NeighbourhoodDetails { get; set; }
        public string PostcodeIncode { get; set; }
        public string PostcodeOutcode { get; set; }
        public bool NeighbourhoodLoaded { get; set; }

    }
}
