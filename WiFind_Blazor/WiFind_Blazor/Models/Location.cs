using System;
using System.ComponentModel.DataAnnotations;

namespace WiFind_Blazor.Models
{
    public class Location
    {
        public int Id { get; set; } // Unique ID for each Location
        public string Name { get; set; } // Name of the location (e.g., "Joe's Café")

        [Required(ErrorMessage = "We need to know the location!")]
        public string LocationName { get; set; } // Place or location ID where the WiFi network is available

        public DateTime Timestamp { get; set; } // Timestamp for when the Location was created or updated
    }
}
