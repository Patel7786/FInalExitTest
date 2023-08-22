using BookEvent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEvent.Repository;

namespace BookEvent.Controllers
{
    public class BookReadingEventController : Controller
    {

        private readonly EventRepository _Event = null;
        private readonly EventTypeRepository _EventType = null;

        public BookReadingEventController(EventRepository eventRepo,EventTypeRepository eventType)
        {
            _Event =eventRepo;
            _EventType = eventType;
        }
        

        public ActionResult Invited()
        {
            return View();
        }

        
        // GET: BookReadingEvent
        
        public async Task<ActionResult> Index(int m)
        {
            if (TempData["doc"] ==null)
            {

                
                return RedirectToAction("LogIn", "Home");
            }
            ViewBag.M = TempData["doc"];
            var d = await _Event.TotalEvent();
            return View(d);
        }


       
        // GET: BookReadingEvent/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            
            var b = await _Event.ViewDetails(id);
            ViewBag.ETVal = await _EventType.getEventTypeValue(b.Type);
            return View(b);
        }

        public async Task<ActionResult> Myevent(string id)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
           
            var b = await _Event.Myevent(id);
            return View(b);
        }

        public async Task<ActionResult> EventInvitedTo(string id)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            var b = await _Event.EventInvitedTo(id);
            return View(b);
        }


        // GET: BookReadingEvent/Create
        public async Task<IActionResult> Create(bool isSuccces = false,int EventID=0)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            ViewData["Title"] = "Create Book";
            ViewBag.IsSuccces = isSuccces;
            ViewBag.EventID = EventID;
            ViewBag.EventType = new SelectList(await _EventType.getEventType(), "ID", "text");
            return View();
        }

        // POST: BookReadingEvent/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookEventModel bookEventModel)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            if (ModelState.IsValid)
            {
                int id = await _Event.create(bookEventModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccces = true ,EventID=id});
                }
            }
            ViewBag.EventType = new SelectList(await _EventType.getEventType(),"ID","text");
            ModelState.AddModelError("", "this is my custome error");
            return View();
            
            
        }

        // GET: BookReadingEvent/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            
            var b = await _Event.ViewDetails(id);
            ViewBag.EventType = new SelectList(await _EventType.getEventType(), "ID", "text");
            ViewBag.ET = await _EventType.getEventTypeValue(b.Type);
            TempData["k"] = id;
            return View(b);
        }

        // POST: BookReadingEvent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookEventModel bookEventModel)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            if (ModelState.IsValid)
            {
                int i= (int)TempData["k"];
                
                var b = await _Event.ViewDetails(i);
                bookEventModel.EventId = b.EventId;
                //bookEventModel.Type = b.Type;
                ViewBag.ET = await _EventType.getEventTypeValue(bookEventModel.Type);
                int id = await _Event.Edit(bookEventModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(SuccessfullyEdited), new { isSuccces = true, EventID = id });
                }
            }
            
            ViewBag.EventType = new SelectList(await _EventType.getEventType(), "ID", "text");
            ModelState.AddModelError("", "this is my custome error");
            return View();
        }


        public async Task<IActionResult> SuccessfullyEdited(bool isSuccces = false, int EventID = 0)
        {
            if (TempData["doc"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            ViewData["Title"] = "Successfully Edited";
            ViewBag.IsSuccces = isSuccces;
            ViewBag.EventID = EventID;
            ViewBag.EventType = new SelectList(await _EventType.getEventType(), "ID", "text");
            return View();
        }


        // GET: BookReadingEvent/Delete/5
       

       
    }
}
