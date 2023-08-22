using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleToweb.Data;
using ConsoleToweb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleToweb.Repository
{

    public class BookRepository
    {
        private readonly BookStoreContext _Context = null;
        public BookRepository(BookStoreContext context)
        {
            _Context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newbook = new Books()
            {
                Author = model.Author,
                Title = model.Title,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
            };

            await _Context.Books.AddAsync(newbook);
            await _Context.SaveChangesAsync();

            return newbook.Id;
        }
        public async Task<List<BookModel>> GetAllBook()
        {
            var books = new List<BookModel>();
            var allbooks = await _Context.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach (var d in allbooks)
                {
                    books.Add(
                        new BookModel()
                        {
                            Author = d.Author,
                            Title = d.Title,
                            Description = d.Description,
                            TotalPages = d.TotalPages,
                            Laungage = d.Laungage,
                            Id = d.Id
                        }); ; 
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookbyID(int id)
        {
            
            var databook = await _Context.Books.FindAsync(id);
             if(databook !=null)
            {
                var b = new BookModel()
                {
                    Author = databook.Author,
                    Title = databook.Title,
                    Description = databook.Description,
                    TotalPages = databook.TotalPages,
                    Id=databook.Id,
                };
                return b;
            }



            // return DataSource().Where (x=> x.Id == id).FirstOrDefault();
            return null;
        }


        public List<BookModel> SearchBook(string author,string title)
        {
            return DataSource().Where(x => x.Author.Contains(author) ||  x.Title.Contains(title)).ToList();
        }


        private List<BookModel> DataSource()
        {
            //-----   problem-in-data-source-cource    ------//

            return new List<BookModel>()
        {
            new BookModel() { Id = 1, Title = "java", Author = "subrhmanayam",Description="this is vary great book of Java",Category="Programming",Laungage="English",TotalPages=210 },
            
            new BookModel() { Id = 2, Title = "MVC", Author = "Prajjawal",Description="this is vary great book of MVC",Category="frame work",Laungage="garman",TotalPages=200 },

            new BookModel() { Id = 3, Title = "C++", Author = "Kumar",Description="this is vary great book of C++",Category="Developer",Laungage="French",TotalPages=180 },

            new BookModel() { Id = 4, Title = "Mv", Author = "shortnameofMVC", Description="this is vary great book of MV",Category="Programming",Laungage="Hindi",TotalPages=110 },

            new BookModel() { Id = 5, Title = "Ja", Author = "ShortnameofJava", Description="this is vary great book of Ja",Category="Back end",Laungage="Urdu",TotalPages=160 },

        };
        }
    }


    
}

