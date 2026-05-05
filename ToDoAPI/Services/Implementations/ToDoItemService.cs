using System.Net.WebSockets;
using ToDoAPI.DTOs;
using ToDoAPI.DTOS;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Interfaces;

namespace ToDoAPI.Services.Implementations
{
    public class ToDoItemService : IToDoItemService
    {

        private readonly IToDoItemRepository _repository;

        public ToDoItemService(IToDoItemRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<ToDoItemDTO>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(p => new ToDoItemDTO {
                UserId= p.UserId, Description = p.Description, IsFinished = p.IsFinished }).ToList();
        }

        public async Task<ToDoItemDTO> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item is null) return null;
            return new ToDoItemDTO
            {
                UserId = item.UserId,
                Description = item.Description,
                IsFinished = item.IsFinished,

            };
        }
        public async Task CreateAsync(ToDoItemDTO dto)
        {
            var item = new ToDoItem
            {
                UserId = dto.UserId,
                Description = dto.Description,
                IsFinished = dto.IsFinished,
            };

            await _repository.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }




        public async Task UpdateAsync(int id, UpdateTDItemDTO dto)
        {
            var item = await _repository.GetByIdAsync(id);
            if(item is null) return;
            item.Description = dto.Description;
            item.IsFinished = dto.IsFinished;

            await _repository.UpdateAsync(item);
        }
    }
}
