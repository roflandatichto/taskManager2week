using taskmanager.Models;
namespace taskmanager.Repo
{
    interface ITaskRepository
    {
        void AddTask(TaskPattern task);
        TaskPattern? GetTaskById(int ID);
        IEnumerable<TaskPattern> GetAll();
        void UpdateTask(int ID, bool IsCompleted);
        void DeleteTask(int ID);
    }
}
