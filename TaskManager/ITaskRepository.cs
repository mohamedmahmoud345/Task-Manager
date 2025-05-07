namespace TaskManager.TaskManager
{
    internal interface ITaskRepository
    {
        void Add(ToDoTask task);
        void Remove(int id);
        bool Update(int Task_id , ToDoTask task);
        ToDoTask FindById(int id);
        IEnumerable<ToDoTask> ListAllTasks();
    }
}
