using TasksApi.Models;
using TasksApi.Repository;

namespace TasksApi.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CreateUser(TasksUser user)
        {
            return _userRepository.ProcessTransaction(user.FirstName, "test title");
        }
    }
}
