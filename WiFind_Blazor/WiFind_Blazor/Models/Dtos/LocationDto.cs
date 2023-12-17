namespace WiFind_Blazor.Models.Dtos
{
    public class LocationDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string LocationName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string WiFiName { get; set; }
        public string Password { get; set; }
    }
}
