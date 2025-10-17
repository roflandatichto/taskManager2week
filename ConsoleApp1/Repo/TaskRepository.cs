using Dapper;
using Microsoft.Data.SqlClient;
using taskmanager.Models;

namespace taskmanager.Repo
{
    class TaskRepository : ITaskRepository
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        public TaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddTask(TaskPattern task)
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

        public void DeleteTask(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM Tasks WHERE Id = @Id";

                connection.Execute(sql, new { Id = ID });
            }
        }

        public IEnumerable<TaskPattern> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Tasks ORDER BY Id";
                return connection.Query<TaskPattern>(sql);
            }
        }

        public TaskPattern? GetTaskById(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Tasks WHERE Id = @Id";

                return connection.QueryFirstOrDefault<TaskPattern>(sql, new { Id = ID });
            }
        }

        public void UpdateTask(int ID, bool IsCompleted)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Tasks SET IsCompleted = @IsCompleted WHERE Id = @Id";

                connection.Execute(sql, new { IsCompleted = IsCompleted, Id = ID });
            }
        }
    }
}
