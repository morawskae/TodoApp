using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Interfaces;

namespace ToDoAPI.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<User> users;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            this.users = _context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await users.ToListAsync();
        }

        public async Task<User> GetUserByID(int id)
        {
            return await users.FindAsync(id);
        }


        public async Task AddUserAsync(User user)
        {
            await users.AddAsync(user);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetUserByID(id);
            if (item is not null)
            {
                users.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}
