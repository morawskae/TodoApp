namespace ToDoAPI.Models
{
    public class ToDoItem
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Description { get; set; }
        public bool IsFinished { get; set; }

        public ToDoItem() { }

        public ToDoItem(int userId, string description)
        {
            this.UserId = userId;
            this.Description = description;
            this.IsFinished = false;
        }
        

    }
}
