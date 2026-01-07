using TaskManagementApplication.DTOs;
using TaskManagementApplication.Models;
using TaskItem = TaskManagementApplication.Models.TaskItem;

namespace TaskManagementApplication.Repository
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetTasks(int userId, TaskQuery query,string role);
        TaskItem GetById(int taskId, int userId);
        int Create(int userId, CreateTaskDto dto);
        void Update(int taskId, int userId, UpdateTaskDto dto);
        void Delete(int taskId, int userId);
    }
}
