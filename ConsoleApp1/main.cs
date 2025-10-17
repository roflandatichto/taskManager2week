using taskmanager.TaskService;

namespace taskmanager
{
    public class Program
    {

        static void Main(string[] args)
        {
            Operation operation = new Operation();

            while (true)
            {
                const int lastOpNum = 5;
                const int firstOpNum = 1;
                Console.WriteLine("Введите номер операции: \n 1. Добавть задачу \n 2. Посмотреть задачу \n 3. Посмотреть все задачи \n 4. Обновить статус задачи \n 5. Удалить задачу ");
                if (!(int.TryParse(Console.ReadLine(), out int choice) || choice > lastOpNum || choice < firstOpNum))
                    continue;
                {
                    switch (choice)
                    {
                        case 1:
                            operation.AddTask();
                            break;
                        case 2:
                            operation.GetTaskById();
                            break;
                        case 3:
                            operation.GetAll();
                            break;
                        case 4:
                            operation.UpdateTask();
                            break;
                        case 5:
                            operation.DeleteTask();
                            break;

                    }
                }
            }
        }
    }
}
