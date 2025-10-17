using taskmanager.Models;
namespace taskmanager.Repo
{
    public interface ITaskRepository
    {
        void AddTask(Models.TaskModel task);
        Models.TaskModel? GetTaskById(int id);
        IEnumerable<Models.TaskModel> GetAll();
        void UpdateTask(int id, bool IsCompleted);
        void DeleteTask(int id);
    }
}
