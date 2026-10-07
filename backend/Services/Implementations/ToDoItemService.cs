using System.Net.WebSockets;
using ToDoAPI.DTOs.ItemDTO;
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

        public async Task<List<GetTDItemDTO>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(p => new GetTDItemDTO {
                Id = p.Id,
               Description = p.Description, 
               IsFinished = p.IsFinished }).ToList();
        }

        public async Task<GetTDItemDTO> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item is null) return null;
            return new GetTDItemDTO
            {
                Id = item.Id,
                Description = item.Description,
                IsFinished = item.IsFinished,

            };
        }
        public async Task CreateAsync(CreateTDItemDTO dto, int userId)
        {
            var item = new ToDoItem
            {
                UserId = userId,
                Description = dto.Description,
                IsFinished = false
            };

            await _repository.AddAsync(item);
        }

        public async Task DeleteAsync(int id, int userId)
        {
            var item = await _repository.GetByIdAsync(id);
            if(item==null) return;

            if (item.UserId != userId) throw new UnauthorizedAccessException();

            await _repository.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, UpdateTDItemDTO dto, int userId)
        {
            var item = await _repository.GetByIdAsync(id);
            if(item is null) return;

            if (item.UserId != userId) throw new UnauthorizedAccessException();

            item.Description = dto.Description;
            item.IsFinished = dto.IsFinished;

            await _repository.UpdateAsync(item);
        }

        public async Task<List<GetTDItemDTO>> GetUsersItems(int userId)
        {
           var items= await _repository.GetUserItems(userId);
           return items.Select(p => new GetTDItemDTO
           {
                Id = p.Id,
                Description = p.Description,
                IsFinished = p.IsFinished
            }).ToList();
        }
    }
}
