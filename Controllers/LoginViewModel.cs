using System.Security.Claims;

namespace chat_signalr.Controllers
{
    public class LoginViewModel
    {
        public string Email { get;  set; }
        public string Password {get;set;}
    }
}