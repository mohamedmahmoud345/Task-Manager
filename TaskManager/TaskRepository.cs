using System.Text.Json;

namespace TaskManager.TaskManager
{
    internal class TaskRepository : ITaskRepository
    {
        private List<ToDoTask> tasks = new();
        private IJsonTaskStorage storage;

        public TaskRepository()
        {
            storage = new JsonTaskStorage();
        }

        // add task
        public void Add(ToDoTask task)
        {
            tasks.Add(task);
            Console.WriteLine($"Tasks Add successfully");
        }

        public void Remove(int taskId)
        {
            tasks.RemoveAll(task => task.Id == taskId);
            Console.WriteLine("Remove successfully");
        }
        // task update 
        public bool Update(int task_id, ToDoTask task)
        {
            if (!tasks.Any(t => t.Id == task_id))
                throw new ArgumentException($"Task with ID {task_id} not found");
            var taskBeforeUpdate = FindById(task_id);

            EqualityTasks(taskBeforeUpdate, task);
            Console.WriteLine("Update successfully");
            return true;
        }
        // equality Tasks
        private void EqualityTasks(ToDoTask oldTask , ToDoTask newtask)
        {
            oldTask.Description = newtask.Description;
            oldTask.Status = newtask.Status;
            oldTask.DueDate = newtask.DueDate;
        }
        //find by id 
        public ToDoTask? FindById(int taskId) => tasks.FirstOrDefault(t => t.Id == taskId);

        // display all tasks
        public IEnumerable<ToDoTask> ListAllTasks()
        {
            foreach (var task in tasks)
            {
                yield return task;
            }
        }
        // file tasks in json file.
        public async Task SaveTasksAsync(string path)
        {
             await storage.SaveTasksAsync(tasks, path);
             Console.WriteLine("Save successfully");
        }

        public async Task LoadTasksAsync(string path)
        {
            var loadedTasks = await storage.LoadTasksAsync(path) ?? new List<ToDoTask>();
            Console.WriteLine($"Loaded {loadedTasks.Count} tasks");  // Debug output
            tasks = loadedTasks;
        }

    }
}
