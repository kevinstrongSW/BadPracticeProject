namespace BadPracticeProject.Models
{
    public class User
    {
        public int Id;
        public string Username;
        public string Password; // stored in plain text
        public decimal Balance;
    }
}
