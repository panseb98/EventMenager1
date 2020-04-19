using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;
using WebAPI.Models.Events.Dto;

namespace WebAPI.Models.Events
{
    public class Event
    {
        [Column("EVENT_ID")]
        public int Id { get; set; }
        [Column("EVENT_NAME")]
        public string EventName { get; set; }
        [Column("EVENT_LOCATION")]
        public string EventLocation { get; set; }
        [Column("EVENT_DESC")]
        public string EventDescription { get; set; }
        [Column("EVENT_TYPE_ID")]
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        [Column("EVENT_CREATION")]
        public DateTime EventCreation { get; set; }
        [Column("ECENT_DATE")]
        public DateTime EventDate { get; set; }
        [Column("EVENT_USER_ID")]
        public int EventUserId { get; set; }
        public User EventUser { get; set; }
        public virtual ICollection<Participant> EventParticipants { get; set; }
        public Event()
        {

        }
        public Event(NewEvent model)
        {
            EventName = model.EventName;
            EventUserId = model.EventUserId;
            EventDate = model.EventDate;
            EventCreation = DateTime.Now;
            EventTypeId = model.EventTypeId;
            EventDescription = model.EventDescription;
            EventLocation = model.EventLocation;
            
        }

    }
}
