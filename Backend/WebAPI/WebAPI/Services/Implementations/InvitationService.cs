using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;
using WebAPI.Models.Events;
using WebAPI.Models.Notification;
using WebAPI.Models.Notification.Dto;
using WebAPI.Models.Notification.ViewModels;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class InvitationService : IInvitationService
    {
        private readonly DataContext _context;
        public InvitationService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddInvitation(AddInvitation invitation)
        {
            
            Invitation dbInvi = new Invitation(invitation);
            if (!await ChechIsExists(invitation))
            {
                _context.Invitations.Add(dbInvi);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddParticipant(int invitationId)
        {
            Invitation invitation = await GetInvitation(invitationId);
            var participant = new Participant() { UserId = invitation.RecipientId, EventId = invitation.EventId, isAdmin = false};
            _context.Participants.Add(participant);
            var ob = await _context.Invitations.FirstAsync(x => x.Id == invitationId);
            ob.IsAccepted = true;
            ob.IsNew = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<InvitationToSend>> GetInvitations(int userId)
        {
            var a = _context.Invitations
                 .Where(x => x.IsAccepted != true && x.RecipientId == userId)
                 .Include(x => x.Sender)
                 .Include(x => x.Event);
         
            var m = a.ToList();

            return await  a.Select(x => new InvitationToSend() { IsNew = x.IsNew, EventName = x.Event.EventName, Sender = x.Sender.Username, InvitationId = x.EventId, InvitationType = "Zaproszenie" }).ToListAsync();
        }

        private async Task<bool> ChechIsExists(AddInvitation addInvitation)
        {
            int isExists = await _context.Invitations.CountAsync(x => 
                (x.SenderId == addInvitation.UserIdSender) 
                && (x.RecipientId == addInvitation.UserIdRept) 
                && (addInvitation.EventId == x.EventId));
            if (isExists == 0) return false;
            return true;
        }
        private async Task<Invitation> GetInvitation(int invitationId)
        {
            var invitation = await _context.Invitations.FirstAsync(x => x.Id == invitationId);
            invitation.IsAccepted = true;
            invitation.IsNew = false;
            await _context.SaveChangesAsync();
            return invitation;
        }
       
    }
}
