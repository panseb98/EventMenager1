using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Notification.Dto;

namespace WebAPI.Services.Interfaces
{
    public interface IInvitationService
    {
        Task AddInvitation(AddInvitation invitation);
    }
}
