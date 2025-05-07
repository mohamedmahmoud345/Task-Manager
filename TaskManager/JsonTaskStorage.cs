using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading.Tasks;
namespace TaskManager.TaskManager
{
    class JsonTaskStorage : IJsonTaskStorage
    {
        // save task to json file
        public async Task<bool> SaveTasksAsync(List<ToDoTask> tasks , string path)
        {
            if(tasks is null)
                throw new ArgumentNullException(nameof(tasks) , "Task Collection cannot be null.");
            if(tasks.Count == 0 )
            {
                throw new InvalidOperationException("Tasks collection cannot be empty");
            }
             var options = new JsonSerializerOptions
             {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
             };

            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(fileStream, tasks, options);
            };
            return true;
        }

        // load task from json file
        public async Task<List<ToDoTask>> LoadTasksAsync(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return new List<ToDoTask>();

                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };
                var objs = await JsonSerializer.DeserializeAsync<List<ToDoTask>>(fileStream, options);

                return objs ?? new List<ToDoTask>();
            }
            catch
            {
                return new List<ToDoTask>();
            }
        }
    }
}
