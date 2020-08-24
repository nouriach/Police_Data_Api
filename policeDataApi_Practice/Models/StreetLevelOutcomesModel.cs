using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Models
{
    public partial class StreetLevelOutcomesModel
    {
            public Category category { get; set; }
            public string date { get; set; }
            public object person_id { get; set; }
            public StreetLevelCrimesModel crime { get; set; }
    }
}
