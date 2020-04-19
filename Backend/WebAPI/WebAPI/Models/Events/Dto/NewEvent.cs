using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events.Dto
{
    public class NewEvent
    {
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public int EventTypeId { get; set; }
        public int EventUserId { get; set; }
        public DateTime EventDate { get; set; }
    }
}
