namespace ToDoAPI.DTOs.UserDTOS
{
    public class UserLoginReqDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginReqDTO() { }

        public UserLoginReqDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
