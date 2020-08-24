using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeDataApi_Practice.Models
{
    public partial class Postcode
    {
        public string status { get; set; }
        public string match_type { get; set; }
        public string input { get; set; }
        public Data data { get; set; }
    }
}
