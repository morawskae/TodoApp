namespace ToDoAPI.DTOs
{
    public class ToDoItemDTO
    {
        public int UserId { get; set; }
        public required string Description { get; set; }
        public bool IsFinished { get; set; }

        public ToDoItemDTO() { }

        public ToDoItemDTO(int userId, string description)
        {
            this.UserId = userId;
            this.Description = description;
            this.IsFinished = false;
        }
    }
}
