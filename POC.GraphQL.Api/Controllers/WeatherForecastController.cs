using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.GraphQL.Service.Interfaces.Services;

namespace POC.GraphQL.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var weathers = await _weatherForecastService.GetAllWeatherForecastAsync();
            
            return Ok(weathers);
        }
    }
}
