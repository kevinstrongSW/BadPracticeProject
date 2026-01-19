using System;
using System.Security.Cryptography;
using System.Text;

namespace BadPracticeProject.Services
{
    public class CryptoService
    {
        // Weak hashing algorithm
        public string HashPassword(string password)
        {
            var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = md5.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
