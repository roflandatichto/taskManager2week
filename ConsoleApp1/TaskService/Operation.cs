using Microsoft.Extensions.Configuration;
using taskmanager.Repo;

namespace taskmanager.TaskService
{
    public class Operation
    {
        private readonly TaskRepository repo;

        public Operation()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);

            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            repo = new TaskRepository(connectionString);
        }

        public void AddTask()
        {
            Console.WriteLine("введите название задачи:");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Название задачи не может быть пустым");
                return;
            }
            Console.WriteLine("введите описание задачи:");
            string description = Console.ReadLine();
            repo.AddSQLTask(new Models.TaskModel { Title = title, Description = description, IsCompleted = false });
            var tasks = repo.GetAllSQL();
            foreach (var t in tasks)
            {
                Console.WriteLine($"ID: {t.ID}, Title: {t.Title}, Description: {t.Description}, IsCompleted: {t.IsCompleted}, CreatedAt: {t.CreatedAt}");
            }
        }
        public void GetTaskById()
        {
            Console.WriteLine("введите ID задачи:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;
            var task = repo.GetSQLTaskById(id);
            if (task != null)
                Console.WriteLine($"ID: {task.ID}, Title: {task.Title}, Description: {task.Description}, IsCompleted: {task.IsCompleted}, CreatedAt: {task.CreatedAt}");
            else
                Console.WriteLine("Задача не найдена");
        }
        public void GetAll()
        {
            var tasks = repo.GetAllSQL();
            if (tasks != null)
                foreach (var t in tasks)
                {
                    Console.WriteLine($"ID: {t.ID}, Title: {t.Title}, Description: {t.Description}, IsCompleted: {t.IsCompleted}, CreatedAt: {t.CreatedAt}");
                }
            else 
            {
                Console.WriteLine("Задачи не найдены");
            }
        }
        public void UpdateTask()
        {
            Console.WriteLine("введите ID задачи:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;
            if (repo.GetSQLTaskById(id) == null)
            {
                Console.WriteLine("Задача не найдена");
                return;
            }
            if (repo.GetSQLTaskById(id).IsCompleted == true)
            {
                bool IsCompleted = false;
                repo.UpdateSQLTask(id, IsCompleted);
            }
            else
            {
                bool IsCompleted = true;
                repo.UpdateSQLTask(id, IsCompleted);
            }
            var task = repo.GetSQLTaskById(id);
            if (task != null)
                Console.WriteLine($"ID: {task.ID}, Title: {task.Title}, Description: {task.Description}, IsCompleted: {task.IsCompleted}, CreatedAt: {task.CreatedAt}");
            else
                Console.WriteLine("Задача не найдена");
        }
        public void DeleteTask()
        {
            Console.WriteLine("введите ID задачи:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return; ;
            if (repo.GetSQLTaskById(id) == null)
                Console.WriteLine("Задача не найдена");
            else
                repo.DeleteSQLTask(id);
        }
    }
}

