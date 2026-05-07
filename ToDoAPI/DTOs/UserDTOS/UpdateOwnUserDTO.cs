namespace ToDoAPI.DTOs.UserDTOS
{
    public class UpdateOwnUserDTO
    {
        public string Password { get; set; }


        public UpdateOwnUserDTO() { }

        public UpdateOwnUserDTO(string password)
        {
            Password = password;
        }

    }
}

