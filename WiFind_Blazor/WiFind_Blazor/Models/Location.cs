using System;
using System.ComponentModel.DataAnnotations;

namespace WiFind_Blazor.Models
{
    public class Location
    {
        public int Id { get; set; } // Unique ID for each Location
        public string Name { get; set; } // Name of the WiFi network (e.g., "GetOffMyLan_5G")

        [Required(ErrorMessage = "Location is required")]
        public string location { get; set; } // Place or location ID where the WiFi network is available

        public DateTime Timestamp { get; set; } // Timestamp for when the Location was created or updated
    }
}
