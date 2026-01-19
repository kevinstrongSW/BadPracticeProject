using BadPracticeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BadPracticeProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        // No authorization
        [HttpGet("settings")]
        public IActionResult GetSettings()
        {
            return Ok(new AdminSettings
            {
                AdminEmail = "admin@badbank.local",
                SmtpPassword = "EmailPassword123"
            });
        }

        // Exposes stack trace
        [HttpGet("crash")]
        public IActionResult Crash()
        {
            try
            {
                throw new Exception("Simulated failure");
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }
    }
}
