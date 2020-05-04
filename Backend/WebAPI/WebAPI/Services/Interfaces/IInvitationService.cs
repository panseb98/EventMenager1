using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Notification.Dto;
using WebAPI.Models.Notification.ViewModels;

namespace WebAPI.Services.Interfaces
{
    public interface IInvitationService
    {
        Task<bool> AddInvitation(AddInvitation invitation);
        Task<bool> AddParticipant(int invitationId);
        Task<List<InvitationToSend>> GetInvitations(int userId); 
    }
}
