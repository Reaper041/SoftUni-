using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Calculate(int num1, int num2)
        {
            this.ViewBag.num1 = num1;
            this.ViewBag.num1 = num2;
            this.ViewBag.num1 = num1 + num2;
            return View("Index");
        }
         
        
        
    }
}