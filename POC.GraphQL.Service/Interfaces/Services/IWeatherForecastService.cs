using POC.GraphQL.Service.Dtos;
using System.Collections.Generic;

namespace POC.GraphQL.Service.Interfaces.Services
{
    public interface IWeatherForecastService
    {
        List<WeatherForecastDto> GetAllWeatherForecastAsync();

    }
}
