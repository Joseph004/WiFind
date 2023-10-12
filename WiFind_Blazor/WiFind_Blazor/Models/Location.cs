namespace WiFind_Blazor.Models
{
    public class Location
    {
        public int Id { get; set; } // ID for each location
        public string Location { get; set; } // Name or description of the location (e.g., café, restaurant, park)
        public string Where { get; set; } // Description of where the location is situated
        public string City { get; set; } // City where the location is situated
        public string Country { get; set; } // Country where the location is situated
        public string Address { get; set; } // Address of the location
        public string Description { get; set; } // Description of the location
        public DateTime Timestamp { get; set; } // Timestamp for when the location was created or updated
    }
}
