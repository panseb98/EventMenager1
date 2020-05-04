using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Notification.ViewModels
{
    public class InvitationToSend
    {
        public int InvitationId { get; set; }
        public string InvitationType { get; set; }
        public string Sender { get; set; }
        public string EventName { get; set; }
        public bool IsNew { get; set; }
    }
}
