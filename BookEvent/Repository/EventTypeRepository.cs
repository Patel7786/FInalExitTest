using BookEvent.DatabaseConnectivity;
using BookEvent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEvent.Repository
{
    public class EventTypeRepository
    {
        private readonly EventContext _Context = null;

        public EventTypeRepository(EventContext context)
        {
            _Context = context; 
        }

        public async Task<List<EventTypeModel>> getEventType()
        {
            var ET = await _Context.EventTypes.Select(x => new EventTypeModel()
            {
                ID = x.ID,
                text = x.text
            }).ToListAsync();
            return ET;
        }

        public async Task<EventTypeModel> getEventTypeValue(int id)
        {
            EventType ET = _Context.EventTypes.Where(x => x.ID == id).FirstOrDefault();
            if (ET != null)
            {
                var x = new EventTypeModel()
                {
                    ID = ET.ID,
                    text = ET.text
                };

                return x;
            }
            return null;
        }
    }

}
