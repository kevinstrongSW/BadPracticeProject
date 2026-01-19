using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BadPracticeProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilityController : ControllerBase
    {
        // Command injection pattern
        [HttpGet("ping")]
        public IActionResult Ping(string host)
        {
            var cmd = $"ping {host}";
            var result = Process.Start("cmd.exe", "/c " + cmd);
            return Ok("Executed");
        }

        // Open redirect
        [HttpGet("go")]
        public IActionResult Go(string url)
        {
            return Redirect(url);
        }
    }
}
