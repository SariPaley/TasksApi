using Microsoft.Data.SqlClient;
using System.Data;
using TasksApi.Models;

namespace TasksApi.Repository
{
    public class UsersRepository : IUserRepository
    {

        

        public IConfiguration _configuration;

        public UsersRepository(IConfiguration configuration)
        {
           _configuration= configuration;   
        }

        public void GetAllUsers(int userId)
        {

            string connectionString = _configuration.GetConnectionString("Connection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TasksUsers WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Define and add the parameter
                    SqlParameter sqlParameter = new SqlParameter("@UserId", userId);
                    command.Parameters.AddWithValue("@userID", userId);
                    command.Parameters.Add(sqlParameter);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Access your data here
                            Console.WriteLine(reader["Name"].ToString());
                        }
                    }
                }
            }

        }



        public bool ProcessTransaction(string FirstName, string Title)
        {

            string connectionString = _configuration.GetConnectionString("Connection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a local transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO Users (FirstName) " +
                        "VALUES (@FirstName)", connection, transaction))
                    {
                        command1.Parameters.AddWithValue("@FirstName", FirstName);
                        command1.ExecuteNonQuery();
                    }

                    using (SqlCommand command2 = new SqlCommand("INSERT INTO Tasks (Title) VALUES (@Title)", connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@Title",Title);
                        command2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Transaction failed: " + ex.Message);
                    try
                    {
                        transaction.Rollback();
                        return false;
                    }
                    catch (Exception rollbackEx)
                    {
                        Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                        return false;
                    }
                }
            }
        }

       
    }
}
