using BadPracticeProject.Data;
using BadPracticeProject.Models;

namespace BadPracticeProject.Services
{
    public class AuthService
    {
        public User Login(string username, string password)
        {
            // SQL injection vulnerability
            var sql = $"SELECT Id, Username, Password, Balance FROM Users WHERE Username = '{username}'";

            var reader = Database.Query(sql);

            if (reader.Read())
            {
                var storedPassword = reader["Password"].ToString();

                // Insecure password comparison
                if (storedPassword == password)
                {
                    return new User
                    {
                        Id = (int)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Password = storedPassword,
                        Balance = (decimal)reader["Balance"]
                    };
                }
            }

            return null;
        }
    }
}
