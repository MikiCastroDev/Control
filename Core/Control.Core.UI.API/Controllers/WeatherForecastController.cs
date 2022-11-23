using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Control.Core.UI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<string[]> _logger;

        public WeatherForecastController(ILogger<string[]> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Summaries.ToArray();
        }
    }
}