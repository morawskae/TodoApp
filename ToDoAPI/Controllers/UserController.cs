using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DTOs.UserDTOS;
using ToDoAPI.Services.Implementations;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Controllers
{

    [Controller]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);

        }

        [Authorize(Roles = "Admin")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            await _service.CreateAsyncUser(dto);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.DeleteAsyncUser(id);
            return Ok();
        }
    }
}