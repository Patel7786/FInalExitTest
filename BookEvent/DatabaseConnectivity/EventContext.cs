using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace BookEvent.DatabaseConnectivity
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Register> Register { get; set; }
    }
   
}
