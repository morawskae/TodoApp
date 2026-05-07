using ToDoAPI.DTOs.UserDTOS;

namespace ToDoAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserDTO>> GetAllAsync();
        Task<GetUserDTO?> GetByIdAsync(int id);
        Task CreateAsyncUser(CreateUserDTO dto);
        Task DeleteAsyncUser(int id);
        Task<string> Login(UserLoginReqDTO dto);

        Task<bool> UpdateOwnUser(int id, UpdateOwnUserDTO dto);
        Task<bool>UpdateUserRole (int id, UpdateUserRoleDTO dto);
    }
}
