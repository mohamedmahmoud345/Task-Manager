namespace TaskManager.TaskManager
{
    internal class ToDoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; } = DateTime.Now;
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        
        public override string ToString()
        {
            return $"Task {Id}\n"+
                    "{\n" +
                    $"\tId: {Id}\n"+
                    $"\tDescription: {Description}\n"+
                    $"\tDueDate: {DueDate}\n"+
                    $"\tTask Status: {Status}\n"+
                    "}";
        }
    }
}
