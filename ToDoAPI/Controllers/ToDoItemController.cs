using Microsoft.AspNetCore.Mvc;
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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ToDoItemDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTDItemDTO dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetUserItems(int userId)
        {
            var items = await _service.GetUsersItems(userId);
            return Ok(items);
        }
    }

}
