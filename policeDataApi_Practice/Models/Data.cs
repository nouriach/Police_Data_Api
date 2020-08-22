namespace policeDataApi_Practice.Models
{
    public partial class Postcode
    {
        public class Data
        {
            public string postcode { get; set; }
            public string status { get; set; }
            public string usertype { get; set; }
            public int easting { get; set; }
            public int northing { get; set; }
            public int positional_quality_indicator { get; set; }
            public string country { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string postcode_no_space { get; set; }
            public string postcode_fixed_width_seven { get; set; }
            public string postcode_fixed_width_eight { get; set; }
            public string postcode_area { get; set; }
            public string postcode_district { get; set; }
            public string postcode_sector { get; set; }
            public string outcode { get; set; }
            public string incode { get; set; }
        }

    }
}
