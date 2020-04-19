using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;
using WebAPI.Models.Notification;
using WebAPI.Models.Notification.Dto;
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

        public async Task AddInvitation(AddInvitation invitation)
        {
            
            Invitation dbInvi = new Invitation(invitation);
            _context.Invitations.Add(dbInvi);
            await _context.SaveChangesAsync();
        }
    }
}
