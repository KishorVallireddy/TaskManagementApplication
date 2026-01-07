
using Dapper;
using System.Data;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Models;
using TaskItem = TaskManagementApplication.Models.TaskItem;



namespace TaskManagementApplication.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbConnection _db;

        public TaskRepository(IDbConnection db)
        {
            _db = db;
        }

        // READ (List with pagination & filtering)
        // 
        //AND
        public IEnumerable<TaskItem> GetTasks(int userId, TaskQuery q, string role)
        {

            string role1 = _db.QuerySingleOrDefault<string>(
                "SELECT Role FROM Users WHERE UserId = @uid",
                new { uid= userId }
            );

            var sql = $@"
        SELECT *
        FROM Tasks
        WHERE (@Status IS NULL OR Status = @Status)
          AND (@Priority IS NULL OR Priority = @Priority) AND UserId = @UserId
        ORDER BY {q.SortBy} {q.SortDir}
        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
            if (role1 == "Admin")
            {
                sql = $@"
        SELECT *
        FROM Tasks
        WHERE (@Status IS NULL OR Status = @Status)
          AND (@Priority IS NULL OR Priority = @Priority)
        ORDER BY {q.SortBy} {q.SortDir}
        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

            }
            return _db.Query<TaskItem>(sql, new
            {
                UserId = userId,
                q.Status,
                q.Priority,
                Skip = (q.Page - 1) * q.PageSize,
                Take = q.PageSize
            });
        }

        // READ (Single)
        public TaskItem GetById(int taskId, int userId)
        {
            
            return _db.QuerySingleOrDefault<TaskItem>(
                "SELECT * FROM Tasks WHERE UserId=@uid AND TaskId=@id ",
                new { id = taskId, uid = userId });
        }

        // CREATE
        public int Create(int userId, CreateTaskDto dto)
        {
            var sql = @"
        INSERT INTO Tasks (UserId, Title, Description, DueDate, Priority, Status)
        VALUES (@UserId, @Title, @Description, @DueDate, @Priority, @Status);
        SELECT CAST(SCOPE_IDENTITY() as int);";

            return _db.ExecuteScalar<int>(sql, new
            {
                UserId = userId,
                dto.Title,
                dto.Description,
                dto.DueDate,
                dto.Priority,
                dto.Status
            });
        }

        // UPDATE
        public void Update(int taskId, int userId, UpdateTaskDto dto)
        {
            var sql = @"
        UPDATE Tasks
        SET Title=@Title,
            Description=@Description,
            DueDate=@DueDate,
            Priority=@Priority,
            Status=@Status
        WHERE TaskId=@TaskId 
            AND UserId=@UserId";

            _db.Execute(sql, new
            {
                TaskId = taskId,
                UserId = userId,
                dto.Title,
                dto.Description,
                dto.DueDate,
                dto.Priority,
                dto.Status
            });
        }

        // DELETE
        public void Delete(int taskId, int userId)
        {
            //
            _db.Execute(
                "DELETE FROM Tasks WHERE TaskId=@id AND UserId=@uid",
                new { id = taskId, uid = userId });
        }
    }


}
