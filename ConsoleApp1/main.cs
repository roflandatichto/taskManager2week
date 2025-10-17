using taskmanager.TaskService;
namespace taskmanager
{
    public class Program
    {
        enum Operations
        {
            addTask = 1,
            showTask,
            showAll,
            updateTask,
            deleteTask

        }
        static void Main(string[] args)
        {
            var operation = new DBConnect.Connection().Connect();
            const int lastOpNum = 5;
            const int firstOpNum = 1;

            while (true)
            {


                Console.WriteLine("Введите номер операции: \n 1. Добавть задачу \n 2. Посмотреть задачу \n 3. Посмотреть все задачи \n 4. Обновить статус задачи \n 5. Удалить задачу ");
                if (!(int.TryParse(Console.ReadLine(), out int choice) || choice > lastOpNum || choice < firstOpNum))
                    continue;

                Operations op = (Operations)choice;
                {
                    switch (op)
                    {
                        case Operations.addTask:
                            operation.AddTask();
                            break;
                        case Operations.showTask:
                            operation.GetTaskById();
                            break;
                        case Operations.showAll:
                            operation.GetAll();
                            break;
                        case Operations.updateTask:
                            operation.UpdateTask();
                            break;
                        case Operations.deleteTask:
                            operation.DeleteTask();
                            break;

                    }
                }
            }
        }
    }
}
