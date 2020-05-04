using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class AddParticipant
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
