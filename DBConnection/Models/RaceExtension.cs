namespace DBConnection.Models;

public partial class Race
{
    public string IconPathWithServer
    {
        get
        {
            return $"https://localhost:7047/{IconPath}";
        }
    }
}
