using System;
using ToDoAPI.Models;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Repositories.Interfaces;

namespace ToDoAPI.Repositories.Implementations
{
	public class ToDoItemRepository : IToDoItemRepository
	{

		private readonly AppDbContext _context;
		private readonly DbSet<ToDoItem> _dbSet;

        public ToDoItemRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ToDoItem>();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<ToDoItem> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(ToDoItem item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ToDoItem item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if(item is not null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}