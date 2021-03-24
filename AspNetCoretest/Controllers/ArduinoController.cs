using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoretest.Models;

namespace AspNetCoretest.Controllers
{
    public class ArduinoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Products()
        {
            return "This is the Arduino Products";
        }

        public IActionResult Desktop() 
        {
            return View();
        }

        public IActionResult Details()
        {
            Unit unit = new Unit() 
            {
                Id = 1,
                Title = "Learning ASP.NET Core 2.0",
                Genre = "Programming & Software Development",
                Price = 45,
                PublishDate = new System.DateTime(2012, 04, 23),
                Authors = new List<string> { "Jason De Oliveira", "Michel Bruchet" }
            }; 
            
            return View(unit);
        }
    }
}