using ToDoAPI.DTOs.ItemDTO;
using ToDoAPI.Repositories.Implementations;

namespace ToDoAPI.DTOS
{
    public interface IToDoItemService
    {
        Task<List<GetTDItemDTO>> GetAllAsync();
        Task<GetTDItemDTO?> GetByIdAsync(int id);
        Task CreateAsync(CreateTDItemDTO dto, int userId);
        Task UpdateAsync(int id, UpdateTDItemDTO dto,int userId);
        Task DeleteAsync(int id,int userId);

        Task<List<GetTDItemDTO>> GetUsersItems(int userId);

    }
}
