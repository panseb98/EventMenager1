using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;
using WebAPI.Models.Events;
using WebAPI.Models.Notification.Dto;

namespace WebAPI.Models.Notification
{
    public class Invitation
    {
        [Column("INVI_ID")]
        public int Id { get; set; }
        [Column("INVI_EVENT_ID")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Column("INVI_SENDER_ID")]
        public int SenderId  { get; set; }
        public User Sender { get; set; }
        [Column("INVI_RECIP_ID")]
        public int RecipientId { get; set; }
        [Column("INVI_RECIP_TYPE")]
        public string Type { get; set; }
        public User Recipient { get; set; }
        [Column("INVI_IS_NEW")]
        public bool IsNew { get; set; }
        [Column("INVI_IS_ACCEPTED")]
        public bool IsAccepted { get; set; }
        public Invitation(AddInvitation invitation)
        {
            EventId = invitation.EventId;
            SenderId = invitation.UserIdSender;
            RecipientId = invitation.UserIdRept;
            IsNew = true;
            IsAccepted = false;
            Type = invitation.InvitationType;
        }
        public Invitation()
        {

        }
    }
}
