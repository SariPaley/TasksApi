using TasksApi.Models;

namespace TasksApi.Services
{
    public interface ITaskService
    {
        public List<TasksWithUsers> GetAllTasksWithUser();
        public List<Tasks> GetAllTasksByUser(int userId);

        public void CreateTask(Tasks task);

        public void UpdateTask(Tasks task);

        public void DeleteTask(Tasks task);
    }
}
