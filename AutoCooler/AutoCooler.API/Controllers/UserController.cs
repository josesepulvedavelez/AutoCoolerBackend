using AutoCooler.Application.IService;
using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCooler.API.Controllers
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

        [HttpGet("GetAllUsersByCompany/{companyId}")]
        public async Task<IActionResult> GetAllUsersByCompany(int companyId)
        {
            var users = await _userService.GetAllUsersByCompany(companyId);

            return Ok(users);
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var userCreate = await _userService.CreateUser(user);
            return Ok(userCreate);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var loggedUser = await _userService.Login(loginRequest.UserName, loginRequest.Password);

            if (loggedUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(loggedUser);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] User user)
        {
            var updatedUser = await _userService.UpdateUser(userId, user);

            if (updatedUser == null)
            {
                return NotFound("User not found.");
            }

            return Ok(updatedUser);
        }

    }
}
