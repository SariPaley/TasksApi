namespace TasksApi.Repository
{
    public interface IUserRepository
    {
        public void GetAllUsers(int userID);

        public bool ProcessTransaction(string FirstName, string Title);
    }
}
