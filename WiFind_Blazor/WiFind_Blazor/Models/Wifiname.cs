namespace WiFind_Blazor.Models
{
    public class WiFiName
    {
        public int Id { get; set; } // Unique ID for each WiFi name
        public string Wifiname { get; set; } // Name of the WiFi network
        public string Passwords { get; set; } // The WiFi passwords
        public DateTime Timestamp { get; set; } // Timestamp for when the WiFi name was created or updated
    }
}
