namespace ToDoAPI.DTOs.UserDTOS
{
    public class UpdateUserRoleDTO
    {
        public string Role { get; set; } = "User";
        public UpdateUserRoleDTO() { }

        public UpdateUserRoleDTO(string role)
        {
            Role = role;

        }
    }
}
