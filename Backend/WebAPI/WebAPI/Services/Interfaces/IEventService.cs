using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization.Dto;
using WebAPI.Models.Events.Dto;

namespace WebAPI.Services.Interfaces
{
    public interface IEventService
    {
        Task<bool> CreateEvent(NewEvent newEvent);
        Task AddReceipt(int eventId, int userId);
        Task AddReceiptItem(NewReceiptItem receiptItem);
        Task AddParticipant();
        Task GetEvent(int eventId);
        Task GetUserEvents(int userId);
        Task GetEventsList();
        Task<List<SimpleEvent>> GetEventsToInvitation(int userInviId, int userToInviId);



    }
}
