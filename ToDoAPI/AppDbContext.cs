using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI
{
    public class AppDbContext: DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users {  get; set; }
    }
}
