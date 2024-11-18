
using Microsoft.EntityFrameworkCore;
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

        public void CreateTask(Tasks task)
        {
            _tasksDbContext.Tasks.Add(task);
            _tasksDbContext.SaveChanges();
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

        public List<Tasks> GetTasks()
        {
            var tasks = _tasksDbContext.Tasks.FromSqlRaw("EXEC Tasks_GetAll").ToList();
            return tasks;
        }
        public List<TasksWithUsers> GetAllTasksWithUsers()
        {

            var tasksWithUsers = _tasksDbContext.Tasks  //tasks table
                           .GroupJoin(
                           _tasksDbContext.TasksUsers,  //users table
                           task => task.UserId,//fk
                           user => user.UserId,//pk
                           (task, users) => new
                           {
                               Task = task,
                               User = users.FirstOrDefault() // Take the first user if it exists, otherwise null
                           })
                           .Select(joinResult => new TasksWithUsers
                            {
                                TaskId=joinResult.Task.TaskId,
                                Title = joinResult.Task.Title,
                                Description = joinResult.Task.Description,
                                UserFirstName = joinResult.User.FirstName,
                                UserLastName = joinResult.User.LastName
                            })
                            .ToList();




            var taskTitlesList2 = new List<Tasks> { new Tasks() { Title = "test", TaskId = 3 } };
            var distinctTitles = _tasksDbContext.Tasks.Distinct(); //return non dulicate valuews
            var unionTitles = _tasksDbContext.Tasks.Union(taskTitlesList2); 

            return tasksWithUsers;


        }


    }
}