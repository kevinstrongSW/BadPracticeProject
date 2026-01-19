using System.Data.SqlClient;

namespace BadPracticeProject.Data
{
    public static class Database
    {
        public static string ConnectionString;

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // SQL Injection vulnerability
        public static SqlDataReader Query(string sql)
        {
            var conn = GetConnection();
            var cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader(); // never closed
        }
    }
}
