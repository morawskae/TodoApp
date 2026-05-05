using ToDoAPI.DTOs;
using ToDoAPI.Repositories.Implementations;

namespace ToDoAPI.DTOS
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemDTO>> GetAllAsync();
        Task<ToDoItemDTO?> GetByIdAsync(int id);
        Task CreateAsync(ToDoItemDTO dto);
        Task UpdateAsync(int id, UpdateTDItemDTO dto);
        Task DeleteAsync(int id);

    }
}
