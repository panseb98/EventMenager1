using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Notification.Dto;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _service;
        public InvitationController(IInvitationService invitationService)
        {
            _service = invitationService;
        }
        [HttpPost("addinvi")]
        public async Task<IActionResult> AddInvitation(AddInvitation invitation)
        {
            if(await _service.AddInvitation(invitation)) return Ok(new { status = "OK", message = "Poprawnie wysłano zaproszenie!" });
            return Ok(new { status = "Exists", message = "Wysłałeś już takie zaproszenie!" }) ;
        }
        [HttpGet("getinvitations")]
        public async Task<IActionResult> GetInvitations(int userId)
        {
            return Ok(await _service.GetInvitations(userId));
        }
        [HttpPost("acceptInvitation")]
        public async Task<IActionResult> AcceptInvitation(int invitationId)
        {
            await _service.AddParticipant(invitationId);
            return Ok();
        }
        
    }
}