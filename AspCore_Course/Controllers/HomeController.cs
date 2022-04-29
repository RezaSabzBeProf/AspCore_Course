using AspCore_Course.Models.DTOs;
using AspCore_Course.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AspCore_Course.Controllers
{
    public class HomeController : Controller
    {
        IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            ViewBag.model = _postService.GetPosts();
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(_postService.Login(model))
            {
                var usermodel = _postService.GetUserByUserName(model.UserName);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,usermodel.Id.ToString()),
                    new Claim(ClaimTypes.Name,usermodel.UserName.ToString()),
                    new Claim(ClaimTypes.Role,usermodel.Role.ToString())
                };
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var propertis = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMonths(1)
                };
                HttpContext.SignInAsync(principal, propertis);
            }
            return RedirectToAction("index");
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("index");

        }
    }
}