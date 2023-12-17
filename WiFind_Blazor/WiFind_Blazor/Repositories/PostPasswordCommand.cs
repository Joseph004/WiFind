namespace WiFind_Blazor.Repositories;
public class PostPasswordCommand
{
    public string Location { get; set; } = "";
    public string Where { get; set; } = "";
    public string WiFiName { get; set; } = "";
    public string Password { get; set; } = "";
}