using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioning.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public WeatherForecastResult Get1_0()
        {
            var rng = new Random();

            var result = new WeatherForecastResult
            {
                ApiVersion = HttpContext.GetRequestedApiVersion().ToString(),
                WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index).ToString(),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
            .ToArray()
            };

            return result;
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public WeatherForecastResult Get1_1()
        {
            var rng = new Random();

            var result = new WeatherForecastResult
            {
                ApiVersion = HttpContext.GetRequestedApiVersion().ToString(),
                WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index).ToLongDateString(),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
            .ToArray()
            };

            return result;
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public WeatherForecastResult Get2_0()
        {
            var rng = new Random();

            var result = new WeatherForecastResult
            {
                ApiVersion = HttpContext.GetRequestedApiVersion().ToString(),
                WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index).ToShortDateString(),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
            .ToArray()
            };

            return result;
        }
    }
}
