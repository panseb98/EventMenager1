using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events.ViewModels
{
    public class EventView
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public string EventType { get; set; }
        public DateTime EventCreation { get; set; }
        public DateTime EventDate { get; set; }
        public int? EventParticipant { get; set; }
        public List<ParticipantView> EventParticipants { get; set; }

        public EventView(Event e, int? participant)
        {
            Id = e.Id;
            EventName = e.EventName;
            EventCreation = e.EventCreation;
            EventDescription = e.EventDescription;
            EventType = e.EventType.EventTypeName;
            EventParticipants = e.EventParticipants.Select(x => new ParticipantView(x)).ToList();
            EventDate = e.EventDate;
            EventParticipant = participant;


        }
    }
}
