using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;
using WebAPI.Models.Authorization.Dto;
using WebAPI.Models.Events;
using WebAPI.Models.Events.Dto;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;
        public EventService(DataContext context)
        {
            _context = context;
        }
        public Task AddParticipant()
        {
            throw new NotImplementedException();
        }

        public Task AddReceipt(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task AddReceiptItem(NewReceiptItem receiptItem)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateEvent(NewEvent newEvent)
        {
            bool isExists = await IsEventExists(newEvent.EventName);
            if (isExists) return false;
            Event newModel = new Event(newEvent);
            try
            {
               // newModel.EventType =await  _context.EventTypes.FirstOrDefaultAsync(x => x.Id == newModel.EventTypeId);
                //newModel.EventUser =await  _context.User.FirstOrDefaultAsync(x => x.Id == newModel.EventUserId);
                _context.Add(newModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception ec)
            {
                var s = ec;
            }

            return true;

        }

        public Task GetEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task GetEventsList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SimpleEvent>> GetEventsToInvitation(int userInviId, int userToInviId)
        {
            var events = await GetUsetEvents(userInviId);
            return events;

        }

        public Task GetUserEvents(int userId)
        {
            throw new NotImplementedException();
        }
        private async Task<bool> IsEventExists(string eventName)
        {
            var count = await _context.Events.CountAsync(x => x.EventName == eventName);
            if (count == 1) return true;
            return false;
        }
        private async Task<List<SimpleEvent>> GetUsetEvents(int userId)
        {
            return await _context.Events.Where(x => x.EventUserId == userId).Select(x => new SimpleEvent() { EventId = x.Id, EventName = x.EventName}).ToListAsync();
        }
        private async Task<List<SimpleEvent>> GetAllUsersEvents(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
