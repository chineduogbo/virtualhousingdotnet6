using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Virtual_Housing.Models;
using Virtual_Housing.Models.ViewModel;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
       public async Task<IActionResult> SignUp()
        {
            HomeViewModel model = new HomeViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(HomeViewModel model)
        {
            var userlogin = await _userService.CreateUser(model.CreateUserDto);
            if (userlogin != null)
            {
                var loginHash = Guid.NewGuid().ToString();
                var identity = new ClaimsIdentity(new[] {
                         new Claim(ClaimTypes.Name, userlogin.FullName),
                         new Claim(ClaimTypes.Email,userlogin.Username),
                         new Claim(ClaimTypes.GroupSid,userlogin.PhoneNumber),
                         new Claim(ClaimTypes.PrimarySid, userlogin._id),
                         new Claim(ClaimTypes.Hash, loginHash)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }
            model.Error = true;
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            HomeViewModel model = new HomeViewModel();           
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(HomeViewModel model)
        {
            var userlogin = await _userService.Login(model.LoginDto);
            if (userlogin != null)
            {
                var loginHash = Guid.NewGuid().ToString();
                var identity = new ClaimsIdentity(new[] {
                         new Claim(ClaimTypes.Name, userlogin.FullName),
                         new Claim(ClaimTypes.Email,userlogin.Username),
                         new Claim(ClaimTypes.GroupSid,userlogin.PhoneNumber),
                         new Claim(ClaimTypes.PrimarySid, userlogin._id),
                         new Claim(ClaimTypes.Hash, loginHash)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }
            model.Error = true;
            return View(model);
         
        }
    }
}