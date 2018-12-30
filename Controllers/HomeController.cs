using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bloggingEngine.Models;

namespace bloggingEngine.Controllers
{
    public class HomeController : Controller
    {
        [UrlActionFilter]
        public IActionResult Index()
        {
            // var relativeurl = Request.Path + Request.QueryString;
            // _logger.LogInformation(relativeurl);
            // Console.WriteLine(Request.Path + Request.QueryString);
            return View();
        }

        [UrlActionFilter]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            // Console.WriteLine(Request.Path + Request.QueryString);
            return View();
        }

        [UrlActionFilter]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [UrlActionFilter]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        [UrlActionFilter]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
