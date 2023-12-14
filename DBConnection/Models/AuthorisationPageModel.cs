namespace DBConnection.Models
{
    public class AuthorisationPageModel
    {
        public AuthorisationPageModel()
        {
            AuthorizationLogin = "";
            AuthorizationPassword = "";
        }
        public string AuthorizationLogin { get; set; }
        public string AuthorizationPassword { get; set; }
    }
}
