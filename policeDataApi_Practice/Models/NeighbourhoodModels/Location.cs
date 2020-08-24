namespace policeDataApi_Practice.Models.NeighbourhoodModels
{
    public partial class LocateSpecificNeighbourhood
    {
        public class Location
        {
            public string name { get; set; }
            public object longitude { get; set; }
            public string postcode { get; set; }
            public string address { get; set; }
            public object latitude { get; set; }
            public string type { get; set; }
            public object description { get; set; }
        }

    }
}
