

using TaskManagementApplication.DTOs;
using TaskManagementApplication.Models;
using TaskItem = TaskManagementApplication.Models.TaskItem;

namespace TaskManagementApplication.Repository
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<TaskItem> GetTasks(int userId, TaskQuery query, string role)
            => _repo.GetTasks(userId, query, role);

        public TaskItem GetById(int id, int userId)
            => _repo.GetById(id, userId);

        public int Create(int userId, CreateTaskDto dto)
            => _repo.Create(userId, dto);

        public void Update(int id, int userId, UpdateTaskDto dto)
            => _repo.Update(id, userId, dto);

        public void Delete(int id, int userId)
            => _repo.Delete(id, userId);
    }

}
