namespace ToDoAPI.DTOs
{
    public class ToDoItemDTO
    {
        public required string description { set; get; }
        public bool IsFinished { get; set; }
    }
}
