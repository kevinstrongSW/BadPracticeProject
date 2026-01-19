namespace BadPracticeProject.Models
{
    public class AdminSettings
    {
        public int Id;
        public string AdminEmail;
        public string SmtpPassword; // stored in plain text
    }
}
