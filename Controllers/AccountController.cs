using Microsoft.AspNetCore.Mvc;
using BadPracticeProject.Services;
using BadPracticeProject.Data;

namespace BadPracticeProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private AuthService _auth = new AuthService();

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var user = _auth.Login(username, password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(user);
        }

        // SQL injection, no validation
        [HttpPost("transfer")]
        public IActionResult Transfer(int fromId, int toId, decimal amount)
        {
            var sql = $"UPDATE Users SET Balance = Balance - {amount} WHERE Id = {fromId};" +
                      $"UPDATE Users SET Balance = Balance + {amount} WHERE Id = {toId};";

            Database.Query(sql); // executes without checking results

            return Ok("Transfer complete");
        }
    }
}
