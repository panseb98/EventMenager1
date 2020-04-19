using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Events
{
    public class EventType
    {
        [Column("EVENT_TYPE_ID")]
        public int Id { get; set; }
        [Column("EVENT_TYPE_NAME")]
        public string EventTypeName { get; set; } 
    }
}
