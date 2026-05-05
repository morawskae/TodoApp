namespace ToDoAPI.DTOs
{
    public class UpdateTDItemDTO
    {
        public required string Description { get; set; }
        public bool IsFinished { get; set; }

        public UpdateTDItemDTO() { }

        public UpdateTDItemDTO(string description, bool isFinished)
        {
            this.Description = description;
            this.IsFinished = isFinished;
        }
    }
}
