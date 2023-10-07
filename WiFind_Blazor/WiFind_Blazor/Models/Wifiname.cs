namespace WiFind_Blazor.Models
{
    public class WiFiName
    
        {
            public int Id { get; set; } // Unique ID for each WiFi name
            public string Name { get; set; } // Name of the WiFi network (e.g., "GetOffMyLan_5G")
            public string Location { get; set; } // Place or location ID where the WiFi network is available
            public DateTime Timestamp { get; set; } // Timestamp for when the WiFi name was created or updated
        }
    
