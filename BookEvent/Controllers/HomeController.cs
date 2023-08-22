using BookEvent.DatabaseConnectivity;
using BookEvent.Models;
using BookEvent.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookEvent.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventRepository _homepast = null;
        private readonly EventContext _Context = null;
        public HomeController(EventRepository eventRepo, EventContext context)
        {
            _homepast = eventRepo;
            _Context = context;
        }

        public async Task<IActionResult> Index()
        {
            var b = await _homepast.HomePastEvent();
            return View(b);
        }

        public async Task<IActionResult> ViewDetails(int Id)
        {
            var b = await _homepast.ViewDetails(Id);
            return View(b);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        

        

        public IActionResult Register(bool isSuccces = false,int isError=1)
        {
            ViewData["Title"] = "Register";
            ViewBag.IsSuccces = isSuccces;
            ViewBag.IsError = isError;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            if (ModelState.IsValid)
            {
                int id = await _homepast.register(registerModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Register), new { isSuccces = true,isError=0});
                }
                else if(id==0)
                {
                    return RedirectToAction(nameof(Register), new { isSuccces = false, isError = 2 });
                }    
                
            }
            
            ModelState.AddModelError("", "this is my custome error");
            return View();
        }


        public IActionResult LogIn(int m)
        {
            ViewBag.Title = "Log in";
            
            ViewBag.Message = m;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            var obj = new LogInModel()
            {
                Email = logInModel.Email,
                Password = logInModel.Password,
            };
            if (ModelState.IsValid)
            {
                var AllUser = _Context.Register.Where(x => x.Email.Equals(logInModel.Email)).FirstOrDefault();
                if (AllUser != null)
                {
                    var Pass = _Context.Register.Where(x => x.Password.Equals(logInModel.Password)).FirstOrDefault();
                    if (Pass != null)
                    {
                        int k = Pass.ID;
                        TempData["doc"] = Pass.Email;
                        TempData["Id"] = Pass.ID;
                        return RedirectToAction("Index", "BookReadingEvent", new { m = k});
                    }
                    else
                    {
                        return RedirectToAction(nameof(LogIn), new { m = 1 }); //Incorrect Password
                    }
                }
                return RedirectToAction(nameof(LogIn), new { m = 2 }); //User does not exist
            }
            ModelState.AddModelError("", "this is my custome error");
            return View();
        }

        /*
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel registerModel)
        {

            if (ModelState.IsValid)
            {
               
                string id =  _homepast.LogIn(registerModel);
                if(id.Equals("Successful Log In"))
                {
                    return RedirectToAction("Index","BookReadingEvent", new { m = id });
                }
                else if(id.Equals("PassWord Is Incorrect"))
                {
                    return RedirectToAction(nameof(LogIn), new { m = id });
                }
                else
                {
                    return RedirectToAction(nameof(LogIn), new { m = id });
                }

            }

            ModelState.AddModelError("", "this is my custome error");
            return View();
        }
        */



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
