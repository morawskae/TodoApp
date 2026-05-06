using ToDoAPI.DTOs.UserDTOS;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Interfaces;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new GetUserDTO
            {
                Username = u.Username,
                Id = u.Id

            }).ToList();
        }

        public async Task<GetUserDTO?> GetByIdAsync(int id)
        {
            var user = await _repository.GetUserByID(id);
            if (user is null) return null;
            return new GetUserDTO
            {
                Username = user.Username,
                Id = user.Id
            };
        }
        
        public async Task CreateAsyncUser(CreateUserDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = dto.PasswordHash,
            };

            await _repository.AddUserAsync(user);

        }

        public async Task DeleteAsyncUser(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

