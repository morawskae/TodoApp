using System;
using ToDoAPI.Models;

namespace ToDoAPI.Repositories.Interfaces
{
	public interface IToDoItemRepository
	{
		Task<IEnumerable<ToDoItem>> GetAllAsync();
		Task<ToDoItem> GetByIdAsync(int id);
		Task AddAsync (ToDoItem item);
		Task UpdateAsync (ToDoItem item);
		Task DeleteAsync(int id);
	}
}