using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleToweb.Repository;
using ConsoleToweb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsoleToweb.Controllers
{
    public class bookController : Controller
    {
        private readonly BookRepository _book = null;

        [ViewData]
        public string Title { get; set; }
        public bookController(BookRepository bookRepository)
        {
            _book = bookRepository;
        }
        public async Task<IActionResult> getAllbook()
        {
            Title = "Get All Book";
            var data= await _book.GetAllBook() ;
            return View(data);
        }
       //[Route("book-details/{id}")]

        public async Task<IActionResult> getBookbyId(int id)
        {
            Title = "GetBookByID";
            var d = await _book.GetBookbyID(id);
            return View(d);
        }

        public List<BookModel> SearchBook(string Author, string Title)
        {
            return _book.SearchBook(Author,Title);
        }

                
        public IActionResult AddNewBOOK(bool isSuccces = false,int bookID=0)
        {
            var model = new BookModel() { Laungage="2" };
            ViewBag.IsSuccces = isSuccces;
            ViewBag.BookID = bookID;
            ViewBag.Launagage = new SelectList(getLaungage(), "id", "text");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBOOK(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                int id = await _book.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBOOK), new { isSuccces = true, bookID = id });
                }
            }
            ViewBag.Launagage =new SelectList( getLaungage(),"id","text");
            ModelState.AddModelError("", "this is my custome error");
            
            return View();
            
        }

        public List<LaungageModel> getLaungage()
        {
            return new List<LaungageModel>
            {
                new LaungageModel(){id = 1, text = "Hindi" },
                new LaungageModel(){id = 2, text = "English" },
                new LaungageModel(){id = 3, text = "German" },
            };
        }

    }
}
