using Microsoft.AspNetCore.Mvc;

namespace AzureBlobServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, World! This is test controller!!!");
        }
    }
}
