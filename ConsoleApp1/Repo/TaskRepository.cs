using Dapper;
using Microsoft.Data.SqlClient;
using taskmanager.Models;

namespace taskmanager.Repo
{
    class TaskRepository : ITaskRepository
    {
        private readonly string connectionString;

        public TaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddTask(Models.TaskModel task)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt)
                           VALUES (@Title, @Description, @IsCompleted, GETDATE())";

                connection.Execute(sql, new
                {
                    task.Title,
                    task.Description,
                    IsCompleted = false
                });
            }
        }

        public void DeleteSQLTask(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM Tasks WHERE Id = @Id";

                connection.Execute(sql, new { Id = ID });
            }
        }

        public IEnumerable<Models.TaskModel> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Tasks ORDER BY Id";
                return connection.Query<Models.TaskModel>(sql);
            }
        }

        public Models.TaskModel? GetTaskById(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Tasks WHERE Id = @Id";

                return connection.QueryFirstOrDefault<Models.TaskModel>(sql, new { Id = ID });
            }
        }

        public void UpdateSQLTask(int ID, bool IsCompleted)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Tasks SET IsCompleted = @IsCompleted WHERE Id = @Id";

                connection.Execute(sql, new { IsCompleted = IsCompleted, Id = ID });
            }
        }
    }
}
