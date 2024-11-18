using TasksApi.Models;

namespace TasksApi.Services
{
    public interface IUserService
    {

         bool CreateUser(TasksUser user);
    }
}
