namespace policeDataApi_Practice.Dtos
{
    public partial class StreetLevelCrimesReadDto
    {
        public class Location
        {
            public string latitude { get; set; }
            public Street street { get; set; }
            public string longitude { get; set; }
        }
    }
}
