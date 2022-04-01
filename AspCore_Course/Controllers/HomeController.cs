using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspCore_Course.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}