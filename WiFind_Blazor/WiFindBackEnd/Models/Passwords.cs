namespace WiFindBackEnd.Models
{
    public class Password
    {
        public int Id { get; set; } // Id for each password
        public string Location { get; set; } // Name or description of the location like a Cafe or a Restaurant
        public string WiFiName { get; set; } // Name of the WiFi network
        public string PasswordValue { get; set; } // The WiFi-password
        public DateTime Timestamp { get; set; } // This is for the timestamop
    }
}
