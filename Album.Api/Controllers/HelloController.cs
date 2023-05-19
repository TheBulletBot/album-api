using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Album.Api.Services;

namespace Album.Api.Controllers
{
    [ApiController]
    [Route("/api")]


    public class HelloController : ControllerBase
    {
        IGreetingService greetingService;
        public HelloController(IGreetingService greetingService, ILogger<HelloController> logger)
        {
            this.greetingService = greetingService;
            _logger = logger;
        }
        private readonly ILogger<HelloController> _logger;

        [HttpGet("hello")]
        public IActionResult Greeting([FromQuery] string? name)
        {
            return Ok(greetingService.Hello(name));
        }
        
    }
}
