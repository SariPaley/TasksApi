
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using TasksApi.Models;
using Tasks = TasksApi.Models.Tasks;

namespace TasksApi.Repository
{
    public class TasksRepository : ITaskRepository
    {
        private readonly TasksDbContext _tasksDbContext;

        public TasksRepository(TasksDbContext tasksDbContext)
        {
            _tasksDbContext = tasksDbContext;
        }

        public  bool CreateTask(Tasks task)
        {

            var user = _tasksDbContext.Users.Where(x => x.UserId == task.UserId);
            if (user.Count()>0)
            {
                _tasksDbContext.Tasks.Add(task);
                _tasksDbContext.SaveChanges();
                return true;
            }
            return false;
        }


        public void DeleteTask(Tasks task)
        {
            _tasksDbContext.Tasks.Remove(task);
            _tasksDbContext.SaveChanges();

        }

        public List<Tasks> GetAllTasks()
        {
            return _tasksDbContext.Tasks.ToList();
        }



        public void UpdateTask(Tasks task)
        {
            _tasksDbContext.Tasks.Update(task);
            _tasksDbContext.SaveChanges();
        }

        public  List<Tasks> GetTasks()
        {
           var tasks= _tasksDbContext.Tasks.FromSqlRaw("EXEC Tasks_GetAll").ToList();
           return tasks;
        }

        public List<TasksWithUsers> GetAllTasksWithUsers()
        {
            var tasksWithUsers = _tasksDbContext.Tasks
                                        .Include(t => t.User)
                                        .Select(t => new TasksWithUsers
                                        {
                                            TaskId = t.TaskId,
                                            Title = t.Title,
                                            Description = t.Description,
                                            
                                            UserFirstName = t.User != null ? t.User.FirstName : null,
                                            UserLastName = t.User != null ? t.User.LastName : null
                                        })
                                        .ToList();

            return tasksWithUsers;

        }

       
    }
}