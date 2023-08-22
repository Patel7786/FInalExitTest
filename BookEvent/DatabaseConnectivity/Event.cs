
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookEvent.Controllers;
using BookEvent.Models;

namespace BookEvent.DatabaseConnectivity
{
    public class Event
    {

        public string UserId { get; set; }
        [Key]
        public int EventId { get; set; }

        public string Title { get; set; }

       
       
        public DateTime Date { get; set; }

        
        public string Location { get; set; }

        
        public DateTime StartTime { get; set; }

        
        public int Type { get; set; }

       
        
        public int? Duration { get; set; }

        
        public string Description { get; set; }

        
        
        public string OtherDetails { get; set; }

       
        public string InviteByEmail { get; set; }

        public int Count { get; set; }

        public string CommentAdded { get; set; }

        public EventType EventType { get; set; }
    }
}
