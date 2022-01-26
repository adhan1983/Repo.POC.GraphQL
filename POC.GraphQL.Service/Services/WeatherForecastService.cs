using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.GraphQL.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {

        private readonly IWeatherForecastRepository _weatherForecastRepository;

        
        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository) => _weatherForecastRepository = weatherForecastRepository;        

        public async Task<List<WeatherForecastDto>> GetAllWeatherForecastAsync()
        {
            var models = await _weatherForecastRepository.GetAllWeatherForecastAsync();

            var dtos = models.
                Select(model => 
                new WeatherForecastDto 
                {
                    ID = model.ID,
                    Date = model.Date,
                    Summary = model.Summary,
                    TemperatureC = model.TemperatureC,
                    TemperatureF = model.TemperatureF
                }).ToList();

            return dtos;
        }
    }
}
