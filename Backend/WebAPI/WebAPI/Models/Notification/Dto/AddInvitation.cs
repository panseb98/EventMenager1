using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Notification.Dto
{
    public class AddInvitation
    {
        public int UserIdSender { get; set; }
        public int UserIdRept { get; set; }
        public int EventId { get; set; }
        public string InvitationType { get; set; }
    }
}
