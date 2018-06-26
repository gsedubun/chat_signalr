using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chat_signalr.Controllers{

[Authorize]
    public class ChatController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}