using taskmanager.Repo;

namespace taskmanager.TaskService
{
    public class TaskService
    {
        private readonly ITaskRepository _repo;
        private readonly string _connectionString;
        public TaskService(string connectionString, ITaskRepository repo)
        {
            _connectionString = connectionString;
            _repo = repo;

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
            _repo.AddTask(new Models.TaskModel { Title = title, Description = description, IsCompleted = false });
            var tasks = _repo.GetAll();
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
            var task = _repo.GetTaskById(id);
            if (task != null)
                Console.WriteLine($"ID: {task.ID}, Title: {task.Title}, Description: {task.Description}, IsCompleted: {task.IsCompleted}, CreatedAt: {task.CreatedAt}");
            else
                Console.WriteLine("Задача не найдена");
        }
        public void GetAll()
        {
            var tasks = _repo.GetAll();
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
            if (_repo.GetTaskById(id) == null)
            {
                Console.WriteLine("Задача не найдена");
                return;
            }
            if (_repo.GetTaskById(id).IsCompleted == true)
            {
                bool IsCompleted = false;
                _repo.UpdateTask(id, IsCompleted);
            }
            else
            {
                bool IsCompleted = true;
                _repo.UpdateTask(id, IsCompleted);
            }
            var task = _repo.GetTaskById(id);
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
            if (_repo.GetTaskById(id) == null)
                Console.WriteLine("Задача не найдена");
            else
                _repo.DeleteTask(id);
        }
    }
}

