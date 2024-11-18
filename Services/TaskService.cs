using TasksApi.Models;
using TasksApi.Repository;

namespace TasksApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        private readonly GenericRepository<Tasks> _tasksRepository;

        public TaskService(ITaskRepository taskRepository, GenericRepository<Tasks> tasksRepository)
        {
            _taskRepository = taskRepository;
            _tasksRepository = tasksRepository;

        }

        public bool CreateTask(Tasks task)
        {
            return _taskRepository.CreateTask(task);
        }

        public void DeleteTask(Tasks task)
        {
            _taskRepository.DeleteTask(task);
        }

        public List<Tasks> GetAllTasksByUser(int userId)
        {
            return _taskRepository.GetAllTasks().Where(x=>x.UserId==userId).ToList();  
        }

        public List<TasksWithUsers> GetAllTasksWithUser()
        {
            return _taskRepository.GetAllTasksWithUsers();
        }

        public void UpdateTask(Tasks task)
        {
           _taskRepository.UpdateTask(task);
        }
    }
}
