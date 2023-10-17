namespace WiFind_Blazor.Models
{
    public class BaseProperty
    {
        public int Id { get; set; } // Id for each password
        public string UserName { get; set; }
        public DateTime CreatedTime { get; set; } // This is for the timestamp
        public DateTime ModifiedTime { get; set; } // This is for the timestamp
    }
}
