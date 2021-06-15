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

        public IActionResult Details(Unit unit)
        { 
                unit.Id = 1;
                unit.Title = "Learning ASP.NET Core 2.0";
                unit.Genre = "Programming & Software Development";
                unit.Price = 45;
                unit.PublishDate = new System.DateTime(2012, 04, 23);
                unit.Authors = new List<string> { "Jason De Oliveira", "Michel Bruchet" };
            string wwwPath = this.Environment.WebRootPath;
            string cc = CultureInfo.CurrentCulture.Name;
            if (cc.IndexOf("en") != -1)
                unit.sourceWebInt = Path.Combine(wwwPath, "data", "WebInt.txt");
            else
                unit.sourceWebInt = Path.Combine(wwwPath, "data", "WebInt.ru.txt");            
            return View(unit);
        }
        public IActionResult Xamarin(Unit unit)
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
    }
}