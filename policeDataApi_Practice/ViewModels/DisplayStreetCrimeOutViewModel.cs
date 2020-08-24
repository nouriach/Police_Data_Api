using policeDataApi_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.ViewModels
{
    public class DisplayStreetCrimeOutViewModel
    {
        public StreetLevelOutcomesModel StreetLevelCrimeOutcome { get; set; }
        public bool CrimeOutcomeLoaded { get; set; }

    }
}
