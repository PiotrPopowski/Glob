using Glob.Server.Infrastructure.Dto;
using Glob.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glob.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ConversationController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("Get/{contact}")]
        public async Task<IActionResult> GetConversation(string contact)
        {
            var chat = await _chatService.GetChatAsync(this.User.Identity.Name, contact);
            return Ok(chat);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var chats = await _chatService.GetAllChatsAsync(this.User.Identity.Name);
            return Ok(chats);
        }

    }
}
