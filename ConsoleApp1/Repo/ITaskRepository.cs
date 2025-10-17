using taskmanager.Models;
namespace taskmanager.Repo
{
    interface ITaskRepository
    {
        void AddSQLTask(Models.TaskModel task);
        Models.TaskModel? GetSQLTaskById(int ID);
        IEnumerable<Models.TaskModel> GetAllSQL();
        void UpdateSQLTask(int ID, bool IsCompleted);
        void DeleteSQLTask(int ID);
    }
}
