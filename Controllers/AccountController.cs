using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace chat_signalr.Controllers{
    public class AccountController : Controller{
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel akunUser, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var isvalid = true;
                if (isvalid)
                {
                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Email, akunUser.Email),
                        new Claim("role","user")
                    };
                    var claimIds = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, "role");
                    var claimsprincipal = new ClaimsPrincipal(claimIds);
                    await HttpContext.SignInAsync(claimsprincipal);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    return View();
                }
            }
            return BadRequest(ModelState);
        }
    }
}