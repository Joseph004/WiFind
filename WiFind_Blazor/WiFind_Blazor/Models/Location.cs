namespace WiFind_Blazor.Models
{
    public class Location : BaseProperty
    {
        public string LocationName { get; set; } // Name or description of the location (e.g., café, restaurant, park)
        public string City { get; set; } // City where the location is situated
        public string Country { get; set; } // Country where the location is situated
        public string Address { get; set; } // Address of the location
        public string Description { get; set; } // Description of the location
        public string WiFiName { get; set; } // Name of the WiFi network
        public string Password { get; set; } // The WiFi-password
    }
}
