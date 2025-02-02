namespace SalesApp.Domain.ValueObjects
{
    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string zipcode { get; set; }
        public GeoLocation geolocation { get; set; }
    }
}
