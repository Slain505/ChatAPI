using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new string[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        }.ToList();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Summaries);
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            var summary = Summaries[index];
            return Ok(summary);
        }
        
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            var summary = Summaries[index];
            Summaries.Remove(summary);
            return Ok(summary);
        }
    }
}
