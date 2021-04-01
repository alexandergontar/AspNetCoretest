using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoretest.Models;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AspNetCoretest.Controllers
{
    public class ArduinoController : Controller
    {
       // CultureInfo cultInfo;
        IWebHostEnvironment Environment;

        public ArduinoController(IWebHostEnvironment _environment) 
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string Products()
        {
            return "This is the Arduino Products";
        }

        public IActionResult Desktop(Unit unit) 
        {
            string wwwPath = this.Environment.WebRootPath;
            string cc = CultureInfo.CurrentCulture.Name;
            if (cc.IndexOf("en") != -1)
                unit.sourceDesktopFile = Path.Combine(wwwPath, "data", "Desktop.txt");
                 else
                  unit.sourceDesktopFile = Path.Combine(wwwPath, "data", "Desktop.ru.txt");
            unit.Id = 113;
            return View(unit);
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