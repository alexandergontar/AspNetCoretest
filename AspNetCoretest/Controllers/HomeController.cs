using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoretest.Models;
using AspNetCoretest.Services;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

namespace AspNetCoretest.Controllers
{
    public class HomeController : Controller
    {
        CultureInfo cultInfo;
        IWebHostEnvironment Environment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _environment)
        {
            _logger = logger;
            Environment = _environment;
        }

        public IActionResult Index(Unit unit)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("first_request"))
            {
                HttpContext.Response.Cookies.Append("first_request", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                System.Diagnostics.Debug.WriteLine("Welcome, new visitor!");
                unit.Firstrequest = "Welcome, new visitor!";
            }
            else
            {
                //DateTime firstRequest = DateTime.Parse(HttpContext.Request.Cookies["first_request"]);
                unit.Firstrequest = "Welcome back, user! You first visited us on: " + HttpContext.Request.Cookies["first_request"];
                System.Diagnostics.Debug.WriteLine("Welcome back, user! You first visited us on: " + unit.Firstrequest);
                //unit.Firstrequest = "Welcome back, user! You first visited us on: " + firstRequest.ToString();
            }
            if (HttpContext.Request.Cookies.ContainsKey("user_comment")) 
            {
                unit.Usercomment = "Your last comment was on: " + HttpContext.Request.Cookies["user_comment"];
                System.Diagnostics.Debug.WriteLine( unit.Usercomment); 
            }
            System.Diagnostics.Debug.WriteLine("Current culture: "+CultureInfo.CurrentCulture.Name);
            return View(unit);
        }

        [HttpGet]
        public IActionResult Privacy(UserForm fm)           
        {
            string wwwPath = this.Environment.WebRootPath;
            string path=Path.Combine(wwwPath,"data", "comments.json");
            var webClient = new WebClient();
           // var json = webClient.DownloadString(@"C:\Users\CSTGONTAA\OneDrive - JT International\Desktop\MVS\AspNetCoretest\AspNetCoretest\wwwroot\Data\comments.json");
            var json = webClient.DownloadString(path);
            fm.usercomments   = JsonConvert.DeserializeObject<Comments>(json);        
            System.Diagnostics.Debug.WriteLine("output:"+json);
            return View(fm);         
        }
        [HttpPost]
        public IActionResult Privacy(string firstName, UserForm fm)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "data", "comments.json");
            // return Content($"Hello {fm.FirstName}");
            if (string.IsNullOrWhiteSpace(fm.UserComment)) fm.UserComment="No comments";
            if (string.IsNullOrWhiteSpace(fm.FirstName)) fm.FirstName = "Anonymous";       
            var webClient = new WebClient();      
            var json = webClient.DownloadString(path);
            Comment cm = new Comment();
            cm.Name = fm.FirstName;
            cm.Message = fm.UserComment;
            cm.MessTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            fm.usercomments = JsonConvert.DeserializeObject<Comments>(json);
            fm.usercomments.comments.Add(cm);            
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, fm.usercomments);             
            }
            HttpContext.Response.Cookies.Append("user_comment", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            return View(fm);
        }

        public IActionResult Details(Unit unit)
        {
            string wwwPath = this.Environment.WebRootPath;
            string cc = CultureInfo.CurrentCulture.Name;
            System.Diagnostics.Debug.WriteLine("Current culture: " + cc);
            unit.sourceFile = Path.Combine(wwwPath, "data", "AP.txt");
            if(cc.IndexOf("en") != -1)
            unit.sourceFile1 = Path.Combine(wwwPath, "data", "Description.txt");
             else unit.sourceFile1 = Path.Combine(wwwPath, "data", "Description.ru.txt");

            return View(unit);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
