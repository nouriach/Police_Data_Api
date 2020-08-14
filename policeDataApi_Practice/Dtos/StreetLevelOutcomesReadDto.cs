using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Dtos
{
    public class StreetLevelOutcomesReadDto
    {
        public class Rootobject
        {
            public Category category { get; set; }
            public string date { get; set; }
            public object person_id { get; set; }
            public Crime crime { get; set; }
        }

        public class Category
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class Crime
        {
            public string category { get; set; }
            public string location_type { get; set; }
            public Location location { get; set; }
            public string context { get; set; }
            public string persistent_id { get; set; }
            public int id { get; set; }
            public string location_subtype { get; set; }
            public string month { get; set; }
        }

        public class Location
        {
            public string latitude { get; set; }
            public Street street { get; set; }
            public string longitude { get; set; }
        }

        public class Street
        {
            public int id { get; set; }
            public string name { get; set; }
        }

    }
}
