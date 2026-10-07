namespace ToDoAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDate { get; set; }

        public string Role { get; set; } = "User";
        public User() { }

        public User(string username, string passwordHash)
        {
            this.Username = username;
            this.PasswordHash = passwordHash;
            this.CreationDate = DateTime.Now;
        }
       
    }
}
