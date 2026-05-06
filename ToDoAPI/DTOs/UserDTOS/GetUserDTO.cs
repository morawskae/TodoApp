namespace ToDoAPI.DTOs.UserDTOS
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime CreationDate { get; set; }

        public GetUserDTO() { }
        public GetUserDTO(string username, int id)
        {
            Id = id;
            Username = username;
   
        }
    }
}
