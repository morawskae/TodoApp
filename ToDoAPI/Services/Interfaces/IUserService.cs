using ToDoAPI.DTOs.UserDTOS;

namespace ToDoAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserDTO>> GetAllAsync();
        Task<GetUserDTO?> GetByIdAsync(int id);
        Task CreateAsyncUser(CreateUserDTO dto);
        Task DeleteAsyncUser(int id);
    }
}
