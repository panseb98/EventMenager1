using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Events.Dto;
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
            if (isAdded) return Ok("Poprawnie dodano EVENT!");
            return BadRequest("Taki Event już istnieje!");
        }

        [HttpGet("getsimpleevents")]
        public async Task<IActionResult> GetSimpleEvents(int userId, int userToId)
        {
            return Ok(await _eventService.GetEventsToInvitation(userId, userToId));
        }
    }
}