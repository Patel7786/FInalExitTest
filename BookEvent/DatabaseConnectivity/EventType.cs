using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEvent.DatabaseConnectivity
{
    public class EventType
    {
        public int ID { get; set; }
        public string text { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
