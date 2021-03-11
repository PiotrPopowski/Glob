using Glob.Server.Api.Requests;
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
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]Register register)
        {
            await _userService.Register(register.Login, register.FirstName, register.LastName, register.Password, register.PublicKey);
            return Ok();
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody]SignIn request)
        {
            var user = await _userService.Login(request.Login, request.Password);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("info/{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var user = await _userService.GetAsync(name);
            return Ok(user);
        }

        [Authorize]
        [HttpPost("add/{userLogin}-{contactLogin}")]
        public async Task<IActionResult> AddContact([FromBody]NewContact request)
        {
            var contact = await _userService.AddContact(User.Identity.Name, request.ContactName, request.SymmetricKey, request.IV);
            return Ok(contact);
        }

        [Authorize]
        [HttpGet("Me/News")]
        public async Task<IActionResult> GetNewContacts()
        {
            var contacts = await _userService.GetNewContacts(User.Identity.Name);
            return Ok(contacts);
        }
    }
}
