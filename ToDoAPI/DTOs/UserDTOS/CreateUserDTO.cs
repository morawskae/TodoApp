namespace ToDoAPI.DTOs.UserDTOS
{
    public class CreateUserDTO
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public CreateUserDTO() { }

        public CreateUserDTO(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}
