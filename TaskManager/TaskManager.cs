using System.Text.Json;

namespace TaskManager.TaskManager
{
    internal class TaskManager 
    {
        private ITaskRepository _taskRepository;
        
        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // add method
        public void AddTask(ToDoTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task) , "Task Can Not Be Null");

            int MaxDescriptionLength = 200;
            if (task.Description.Length > MaxDescriptionLength)
                throw new ArgumentException($"Description length cannot exceed {MaxDescriptionLength} characters.");
            bool CheckId = _taskRepository.ListAllTasks().Any(t => t.Id == task.Id);
            if(CheckId)
                throw new InvalidOperationException($"A task with ID {task.Id} already exists.");

            _taskRepository.Add(task);
        }

        // filter tasks
        public void FilterTaskByStatus()
        {
            var GroupBySatus = _taskRepository.ListAllTasks().GroupBy(x => x.Status).ToList();

            foreach( var status in GroupBySatus)
            {
                Console.WriteLine($"--{status.Key}");
                foreach(var task in status)
                    Console.WriteLine($"       {task.Id}.");
            }
        }

        // update task
        public bool UpdateTask(int task_id, ToDoTask task)
        {
            if (task is null)
                throw new ArgumentException();
            return _taskRepository.Update(task_id, task);
        }

        // task deletion
        public bool RemoveTask(int task_Id)
        {
            var checkTask = _taskRepository.ListAllTasks().Where(task => task.Id == task_Id);
            if (checkTask == null)
                throw new NullReferenceException("The Task Not Exist");
            _taskRepository.Remove(task_Id);
            return true;
        }
        
        // display tasks
        public void DisplayTasks()
        {
            foreach(var task in _taskRepository.ListAllTasks())
            {
                Console.WriteLine(task);
            }
        }      
    }
}
