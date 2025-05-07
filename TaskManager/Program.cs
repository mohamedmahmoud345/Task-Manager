
namespace TaskManager.TaskManager
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task1 = new ToDoTask
            {
                Id = 1,
                Description = "Finish C# console project",
                DueDate = DateTime.Today.AddDays(2),
                Status = 0
            };

            var task2 = new ToDoTask
            {
                Id = 2,
                Description = "Review GitHub README.md",
                DueDate = DateTime.Today.AddDays(1),
                Status = 0
            };

            var task3 = new ToDoTask
            {
                Id = 3,
                Description = "Push project to GitHub",
                DueDate = DateTime.Today.AddDays(3),
                Status = 0
            };

            var task4 = new ToDoTask
            {
                Id = 4,
                Description = "Test JSON file loading",
                DueDate = DateTime.Today.AddDays(4),
                Status = 0
            };


            TaskRepository taskRepository = new TaskRepository();
            TaskManager taskManager = new TaskManager(taskRepository);

            var path = "C:\\progg\\project c#\\TaskManager\\Tasks.json";

            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);
            taskManager.AddTask(task4);

            Console.WriteLine("=== TASK MANAGER DEMO ===");

            // 1. Initial state
            Console.WriteLine("\n1. Initial Tasks:");
            taskManager.DisplayTasks();

            // 2. Add new task
            Console.WriteLine("\n2. Adding new task...");
            taskManager.AddTask(new ToDoTask
            {
                Id = 5,
                Description = "Document the API",
                Status = TaskStatus.Pending
            });

            // 3. Update task
            Console.WriteLine("\n3. Updating task...");
            taskManager.UpdateTask(1, new ToDoTask
            {
                Id = 1,
                Description = "Finish C# project (priority)",
                Status = TaskStatus.InProgress
            });
            taskManager.UpdateTask(4, new ToDoTask
            {
                Id = 4,
                Description = "Test JSON file loading",
                DueDate = DateTime.Today.AddDays(4),
                Status = TaskStatus.Completed
            });

            // 4. Remove task
            Console.WriteLine("\n4. Removing task...");
            taskManager.RemoveTask(2);

            // 5. Final state
            Console.WriteLine("\n5. Final Task List:");
            taskManager.DisplayTasks();

            // 6. Save changes
            Console.WriteLine("\n6. Saving changes...");
            await taskRepository.SaveTasksAsync(path);

        }
    }
}
