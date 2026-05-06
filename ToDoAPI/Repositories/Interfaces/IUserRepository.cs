using ToDoAPI.Models;

namespace ToDoAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserByID(int id);
        Task AddUserAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
