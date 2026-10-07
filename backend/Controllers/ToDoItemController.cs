using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoAPI.DTOs.ItemDTO;
using ToDoAPI.DTOS;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/toDoItems")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _service;
        public ToDoItemController(IToDoItemService service)
        {
            _service = service;
        }


        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [Authorize(Roles ="User")]
        [HttpPost]
        public async Task<IActionResult> AddItem(CreateTDItemDTO dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _service.CreateAsync(dto,userId);
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTDItemDTO dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _service.UpdateAsync(id, dto, userId);
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _service.DeleteAsync(id, userId);
            return Ok();
        }
        [Authorize(Roles = "User")]
        [HttpGet("my-items")]
        public async Task<IActionResult> GetUserItems()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var items = await _service.GetUsersItems(userId);
            return Ok(items);
        }
    }

}
