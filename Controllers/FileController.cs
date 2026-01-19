using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BadPracticeProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            // No validation, no size limit, no file type checks
            var path = Path.Combine("uploads", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Ok("Uploaded");
        }
    }
}
