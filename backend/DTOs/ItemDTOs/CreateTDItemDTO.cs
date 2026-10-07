namespace ToDoAPI.DTOs.ItemDTO
{
    public class CreateTDItemDTO
    {
        public required string Description { get; set; }

        public CreateTDItemDTO() { }

        public CreateTDItemDTO(string description)
        {
            this.Description = description;
        }
    }
}
