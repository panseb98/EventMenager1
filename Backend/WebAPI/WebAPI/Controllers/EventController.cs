using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Models.Events.Dto;
using WebAPI.Models.Events.ViewModels;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("addevent")]
        public async Task<IActionResult> AddEvent(NewEvent model)
        {
            bool isAdded = await _eventService.CreateEvent(model);
            if (isAdded) return Ok(new { Status = "OK", Message = "Poprawnie dodano Event!" });
            return Ok(new { Status = "Exists", Message = "Taki Event już istnieje!" });
        }
        [HttpPost("addparticipant")]
        public async Task<IActionResult> AddParticipant(AddParticipant newParticipant)
        {
            bool isAdded = await _eventService.AddParticipant(newParticipant.EventId, newParticipant.UserId);
            if (isAdded) return Ok(new { Status = "OK", Message = "Poprawnie dołączono do eventu" });
            return Ok(new { Status = "Exists", Message = "Już jesteś zapisany na to wydażenie" });
        }

        [HttpPost("addreceiptitem")]
        public async Task<IActionResult> AddReceiptItem(NewReceiptItem newreceipt)
        {
            bool isAdded = await _eventService.AddReceiptItem(newreceipt);
            if (isAdded) return Ok(new { Status = "OK", Message = "Poprawnie dodano nową pozycje" });
            return Ok(new { Status = "Exists", Message = "Już taka pozycja jest na paragonie" });
        }
        [HttpGet("getsimpleevents")]
        public async Task<IActionResult> GetSimpleEvents(int userId, int userToId)
        {
            return Ok(await _eventService.GetEventsToInvitation(userId, userToId));
        }
        [HttpGet("getreceiptitems")]
        public async Task<IActionResult> GetReceiptItems(int participant)
        {
            return Ok(await _eventService.GetReceiptItem(participant));
        }
        [HttpGet("getevent")]
        public async Task<IActionResult> GetEvent(int eventId, int userId)
        {
            var s = await _eventService.GetEvent(eventId, userId);
            return Ok(s);
        }
        [HttpGet("geteventsforuser")]
        public async Task<IActionResult> GetEventsForUser(int userId)
        {
            var s = await _eventService.GetEventsForUser(userId);
            return Ok(s);
        }
        [HttpPost("removeReceiptItem")]
        public async Task<IActionResult> RemoveReceiptItem(RemoveItem receiptItem)
        {
            var s = await _eventService.RemoveReceiptItem(receiptItem);
            return Ok(s);
        }
    }
}