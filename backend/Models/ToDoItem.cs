namespace ToDoAPI.Models
{
    public class ToDoItem
    {

        public int Id { get; set; }
        public int UserId { get; set; }

        public User Owner { get; set; }
        public required string Description { get; set; }
        public bool IsFinished { get; set; } = false;

        public ToDoItem() { }

        public ToDoItem(int userId, string description, User owner)
        {
            this.UserId = userId;
            this.Description = description;
            this.Owner = owner;
        }
        

    }
}
