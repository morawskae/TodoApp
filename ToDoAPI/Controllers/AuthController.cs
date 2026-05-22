using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using ToDoAPI.DTOs.UserDTOS;
using ToDoAPI.Services.Implementations;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _service;

        public AuthController( IUserService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginReqDTO dto)
        {
            var token = await _service.Login(dto);
            if (string.IsNullOrEmpty(token)) return Unauthorized("Invalid credentials");
            return Ok(new { token });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDTO dto)
        {
            try{
            await _service.CreateAsyncUser(dto);
            return Ok();}
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
