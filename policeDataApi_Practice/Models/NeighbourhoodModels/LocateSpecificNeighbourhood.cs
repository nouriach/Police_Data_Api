using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Models.NeighbourhoodModels
{
    public partial class LocateSpecificNeighbourhood
    {
        public string url_force { get; set; }
        public Contact_Details contact_details { get; set; }
        public string name { get; set; }
        public Link[] links { get; set; }
        public Centre centre { get; set; }
        public Location[] locations { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public string population { get; set; }
    }
}
