using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScriptManagerTagHelper.WebSample.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

       
        public IActionResult Videos()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
