namespace TaskManager.TaskManager
{
    internal interface IJsonTaskStorage
    {
        Task<bool> SaveTasksAsync(List<ToDoTask> tasks, string path);
        Task<List<ToDoTask>> LoadTasksAsync(string path);
    }
}
