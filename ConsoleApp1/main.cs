using taskmanager.Repo;

namespace taskmanager
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            ITaskRepository repo = new TaskRepository(connectionString);
            while (true)
            {
                Console.WriteLine("Введите номер операции: \n 1. Добавть задачу \n 2. Посмотреть задачу \n 3. Посмотреть все задачи \n 4. Обновить статус задачи \n 5. Удалить задачу ");
                if (!int.TryParse(Console.ReadLine(), out int operation) && operation > 5 && operation < 1)
                    continue;
                {
                    switch (operation)
                    {
                        case 1:
                            Console.WriteLine("введите название задачи:");
                            string title = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(title))
                            {
                                Console.WriteLine("Название задачи не может быть пустым");
                                break;
                            }
                            Console.WriteLine("введите описание задачи:");
                            string description = Console.ReadLine();
                            repo.AddTask(new Models.TaskPattern { Title = title, Description = description, IsCompleted = false });
                            break;
                        case 2:
                            Console.WriteLine("введите ID задачи:");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                                continue;
                            var task = repo.GetTaskById(id);
                            if (task != null)
                                Console.WriteLine($"ID: {task.ID}, Title: {task.Title}, Description: {task.Description}, IsCompleted: {task.IsCompleted}, CreatedAt: {task.CreatedAt}");
                            else
                                Console.WriteLine("Задача не найдена");
                            break;
                        case 3:
                            var tasks = repo.GetAll();
                            if (tasks != null)
                                foreach (var t in tasks)
                                {
                                    Console.WriteLine($"ID: {t.ID}, Title: {t.Title}, Description: {t.Description}, IsCompleted: {t.IsCompleted}, CreatedAt: {t.CreatedAt}");
                                }
                            else
                            {
                                Console.WriteLine("Задачи не найдены");
                            }
                            break;
                        case 4:
                            Console.WriteLine("введите ID задачи:");
                            if (!int.TryParse(Console.ReadLine(), out id))
                                continue;
                            if (repo.GetTaskById(id) == null)
                            {
                                Console.WriteLine("Задача не найдена");
                                continue;
                            }
                            if (repo.GetTaskById(id).IsCompleted == true)
                            {
                                bool IsCompleted = false;
                                repo.UpdateTask(id, IsCompleted);
                            }
                            else
                            {
                                bool IsCompleted = true;
                                repo.UpdateTask(id, IsCompleted);
                            }
                            break;
                        case 5:
                            Console.WriteLine("введите ID задачи:");
                            if (!int.TryParse(Console.ReadLine(), out id))
                                continue;
                            if (repo.GetTaskById(id) == null)
                                Console.WriteLine("Задача не найдена");
                            else
                                repo.DeleteTask(id);
                            break;

                    }
                }
            }
        }
    }
}
