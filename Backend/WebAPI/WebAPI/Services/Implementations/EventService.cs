using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Database;
using WebAPI.Models.Authorization.Dto;
using WebAPI.Models.Events;
using WebAPI.Models.Events.Dto;
using WebAPI.Models.Events.ViewModels;
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
        public async Task<bool> AddParticipant(int eventId, int userId)
        {
            var count = await _context.Participants.CountAsync(x => x.EventId == eventId && x.UserId == userId);
            if (count == 1) return false;
            try
            {
                _context.Participants.Add(new Participant() { EventId = eventId, UserId = userId, isAdmin = false });
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ec)
            {
                var s = 1;
            }
            return true;
        }


        public async Task<bool> AddReceiptItem(NewReceiptItem receiptItem)
        {
            bool CheckExists(int participant, int amount, string name, double price)
            {
                int a = _context.ReceiptItems.Count(x => (x.ParticipantId == participant) && (x.Price == price) && (x.ProductName == name));
                return a == 0 ? false : true;
                   
            }

            var a = await _context.Participants.FirstAsync(x => x.Id == receiptItem.Participant);

            if (CheckExists(receiptItem.Participant, receiptItem.Count, receiptItem.PositionName, receiptItem.Value)) return false;

            _context.ReceiptItems.Add(new ReceiptItem() { Amount = receiptItem.Count, ParticipantId = receiptItem.Participant, Price = receiptItem.Value, ProductName = receiptItem.PositionName });
            await _context.SaveChangesAsync();
            return true;
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
              //  newModel.EventParticipants = new ICollection<Participant>();
                newModel.EventParticipants.Add(new Participant() { EventId = newModel.Id, isAdmin = true, UserId = newModel.EventUserId });
                _context.Events.Add(newModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception ec)
            {
                var s = ec;
            }

            return true;

        }

        public async Task<EventView> GetEvent(int eventId, int userId)
        {
            int? participantId;
            var s = await _context.Events
                .Where(x => x.Id == eventId)
                .Include(x => x.EventType)
                .Include(x => x.EventParticipants).ThenInclude(x => x.Items)
                .Include(x => x.EventParticipants).ThenInclude(x => x.User)
                .ToListAsync()
                ;
            var parti = await _context.Participants.FirstAsync(x => x.UserId == userId && x.EventId == eventId);
            if (parti == null)
            {
                participantId = null;
            }

            else
            {
                participantId = parti.Id;
            }
            var m =  s.Select(x => new EventView(x, participantId)).First();
            return m;
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
            return await _context.Events
                .Where(x => x.EventUserId == userId)
                .Select(x => new SimpleEvent() { EventId = x.Id, EventName = x.EventName})
                .ToListAsync();
        }
        public async Task<List<NewReceiptItem>> GetReceiptItem(int participant)
        {
            var a = await _context.Participants
                .Include(x => x.Items)
                .FirstAsync(x => x.Id == participant);


            return a.Items.OrderByDescending(x => x.Id).Select(x => new NewReceiptItem() { Id = x.Id, Count = x.Amount, Participant = participant, PositionName = x.ProductName, Value = x.Price }).ToList();
        }

        public async Task<List<EventToList>> GetEventsForUser(int userId)
        {
            var s = _context.Events
                .Include(x => x.EventParticipants)
                .Include(x => x.EventType)
                .Where(x => x.EventParticipants
                    .Select(x => x.UserId)
                    .Contains(userId))
                .Select(x => new EventToList() { EventDate = x.EventDate, EventId = x.Id, EventName = x.EventName, EventType = x.EventType.EventTypeName, EventLoc = x.EventLocation });
            
            return await s.ToListAsync();
        }

        public Task<bool> AddReceipt(NewReceiptItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveReceiptItem(RemoveItem receiptId)
        {
            var item = await _context.ReceiptItems.FirstAsync(x => x.Id == receiptId.Id);
            _context.ReceiptItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
