using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization.Dto;
using WebAPI.Models.Events;
using WebAPI.Models.Events.Dto;
using WebAPI.Models.Events.ViewModels;

namespace WebAPI.Services.Interfaces
{
    public interface IEventService
    {
        Task<bool> CreateEvent(NewEvent newEvent);
        Task<bool> AddReceipt(NewReceiptItem item);
        Task<bool> AddReceiptItem(NewReceiptItem receiptItem);
        Task<List<NewReceiptItem>> GetReceiptItem(int participant);
        Task<bool> AddParticipant(int eventId, int userId); 
        Task<EventView> GetEvent(int eventId, int userId);
        Task GetUserEvents(int userId);
        Task GetEventsList();
        Task<List<SimpleEvent>> GetEventsToInvitation(int userInviId, int userToInviId);
        Task<List<EventToList>> GetEventsForUser(int userId);
        Task<bool> RemoveReceiptItem(RemoveItem receiptId);


    }
}
