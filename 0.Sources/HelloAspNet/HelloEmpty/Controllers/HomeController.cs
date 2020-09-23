using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HelloMessage msg = new HelloMessage()
            {
                Message = "Welcome to ASP.NET MVC!"
            };

            ViewBag.Noti = "Input message and click submit";

            return View(msg);
        }

        // Post를 처리하는 Index
        [HttpPost]
        public IActionResult Index(HelloMessage obj)
        {
            ViewBag.Noti = "Message Changed";
            return View(obj);
        }
    }
}
