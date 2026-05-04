namespace ToDoAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }

        public User() { }

        public User(string username, string passwordHash)
        {
            this.Username = username;
            this.PasswordHash = passwordHash;
        }
       
    }
}
