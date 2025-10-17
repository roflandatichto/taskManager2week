using Microsoft.Extensions.Configuration;
using taskmanager.Repo;

namespace taskmanager.DBConnect
{
    public class Connection
    {
        public TaskService.TaskService Connect()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true).Build();
            string connectionString = builder.GetConnectionString("DefaultConnection");
            ITaskRepository repository = new TaskRepository(connectionString);
            var repo = new TaskService.TaskService(connectionString, repository);
            return repo;
        }
    }
}
