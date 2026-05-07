using Microsoft.AspNetCore.Identity;
using ToDoAPI.DTOs.UserDTOS;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Interfaces;
using ToDoAPI.Services.Interfaces;

namespace ToDoAPI.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;
        private readonly TokenService _tokenService;
        private readonly IPasswordHasher<User> _passHasher;

        public UserService(IUserRepository repository, TokenService tokenService ,IPasswordHasher<User> passHasher)
        {
            _repository = repository;
            _tokenService = tokenService;
            _passHasher = passHasher;
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
            };
            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, dto.Password);

            await _repository.AddUserAsync(user);

        }

        public async Task DeleteAsyncUser(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<string> Login(UserLoginReqDTO dto)
        {
            var user = await _repository.GetUserByUsername(dto.Username);
            if (user == null) return null;

            var result = _passHasher.VerifyHashedPassword(
                user,
                user.PasswordHash, dto.Password
                );
            if(result ==PasswordVerificationResult.Failed) return null;
            return _tokenService.GenerateToken(user);
        }

        public async Task<bool> UpdateOwnUser(int id, UpdateOwnUserDTO dto)
        {
            var user = await _repository.GetUserByID(id);
            if (user is null) return false;

            user.PasswordHash = _passHasher.HashPassword(user, dto.Password);
            await _repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateUserRole(int id, UpdateUserRoleDTO dto)
        {
            var user = await _repository.GetUserByID(id);
            if (user is null) return false;

            user.Role = dto.Role;
            await _repository.UpdateAsync(user);
            return true;
        }
    }
}

