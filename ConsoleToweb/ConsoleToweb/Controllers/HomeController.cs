using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleToweb.Models;
using System.Dynamic;
namespace ConsoleToweb.Controllers
{
    public class  HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public IActionResult Index()
        {
            //learn About ViewBag--->
            /*
            ViewBag.t = 123;
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.name = "Viewdata Name";
            ViewBag.Data = data;
            ViewBag.Type = new BookModel() { Id = 234, Title = "Viewbag Title" };
            */
            Title = "Home Page";
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public ViewResult ContactUs()
        {
            // var d = new { id = 1, Title = "pk univar" };
            Title = "Contact";
            return View();
        }

        public ViewResult Temp()
        {
            return View("~/TempView/pkview.cshtml");
        }

        public ViewResult aboutUs ()
        {
            Title = "About Us";
            return View();
        }
    }
}
