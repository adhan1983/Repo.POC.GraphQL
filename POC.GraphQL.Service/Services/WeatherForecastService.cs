using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POC.GraphQL.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        public List<WeatherForecastDto> GetAllWeatherForecastAsync()
        {
            var rng = new Random();
            return Enumerable.Range(1, 1000).Select(index => new WeatherForecastDto()
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
        }
    }
}
