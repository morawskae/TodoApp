namespace ToDoAPI.DTOs.ItemDTO
{
    public class GetTDItemDTO
    {
        public required string Description { get; set; }
        public bool IsFinished { get; set; }

        public GetTDItemDTO() { }

        public GetTDItemDTO(string description, bool isFinished)
        {
            this.Description = description;
            this.IsFinished = isFinished;
        }
    }
}
