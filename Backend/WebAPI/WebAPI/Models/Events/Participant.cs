using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;

namespace WebAPI.Models.Events
{
    public class Participant
    {
        [Column("PARTICIPANT_ID")]
        public int Id { get; set; }
        [Column("PARTICIPANT_USER_ID")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Column("PARTICIPANT_EVENT_ID")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Column("PARTICIPANT_IS_ADMIN")]
        public bool isAdmin { get; set; }
        public virtual ICollection<ReceiptItem> Items { get; set; }
    }
}
