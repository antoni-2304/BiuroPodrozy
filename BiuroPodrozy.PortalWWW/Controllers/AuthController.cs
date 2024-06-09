using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Models;
using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BiuroPodrozy.PortalWWW.Controllers
{
    public class AuthController : Controller
    {
        private readonly ReferenceAPI BiuroPodrozyService;
        private readonly ITokenService _tokenService;

        public AuthController(IConnectToAPI BiuroPodrozyService, ITokenService _tokenService)
        {
            this.BiuroPodrozyService = BiuroPodrozyService.Connect();
            this._tokenService = _tokenService;
        }
        //public Task<IActionResult> Register()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterView()
        {
            return View();
        }

        public async Task<IActionResult> Register([Bind("UserName,Email,Password,RepeatPassword")] RegisterModel RegisterModel)
        {
            if (ModelState.IsValid)
            {
                var reponse = await BiuroPodrozyService.RegisterUserAsync(new RegisterModelDTO() { UserName = RegisterModel.UserName, Email = RegisterModel.Email, Password = RegisterModel.Password });
                if (reponse)
                {
                    await Login(new LoginModel() { Email = RegisterModel.Email, Password = RegisterModel.Password });
                }
                return View("Index", "Home");
            }
            return View("RegisterView", RegisterModel);
        }

        public IActionResult LoginView()
        {
            return View();
        }
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginModel LoginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await BiuroPodrozyService.AuthenticateUserAsync(new LoginModelDTO() { Email = LoginModel.Email, Password = LoginModel.Password });
                    if (response.AccessToken != null)
                    {
                        await _tokenService.SaveTokenAsync(response.AccessToken, response.RefreshToken);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, LoginModel.Email),
                            new Claim("AccessToken", response.AccessToken)
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    TempData["Logged"] = "incorrect";
                    return View("LoginView", LoginModel);
                }
            }
            TempData["Logged"] = "incorrect";
            return View("LoginView", LoginModel);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            Response.Cookies.Delete("AccessToken");
            Response.Cookies.Delete("RefreshToken");

            return RedirectToAction("Index", "Home");
        }
    }
}
