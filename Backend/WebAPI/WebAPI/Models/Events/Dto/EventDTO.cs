using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;

namespace WebAPI.Models.Events.Dto
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public DateTime EventCreation { get; set; }
        public DateTime EventDate { get; set; }
        public int EventUserId { get; set; }
        public User EventUser { get; set; }
        public virtual ICollection<Participant> EventParticipants { get; set; }
    }
}
