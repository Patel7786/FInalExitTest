using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleToweb.Data
{
    public class BookStoreContext: DbContext
    { 
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {

        }

        //Entity class -->
        public DbSet<Books> Books { get; set; }
    }
}
