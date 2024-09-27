using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaApp.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = "Welcome to the Cinema Web App";

            return View();
        }
    }
}
