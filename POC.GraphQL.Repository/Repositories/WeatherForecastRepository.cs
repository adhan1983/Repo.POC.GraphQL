using Microsoft.EntityFrameworkCore;
using POC.GraphQL.Repository.Data.Context;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.GraphQL.Repository.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        protected SchoolContext _schollContext;        
        
        public WeatherForecastRepository(SchoolContext schollContext) => _schollContext = schollContext;

        public async Task<List<WeatherForecast>> GetAllWeatherForecastAsync()
        {
            var models = await _schollContext.
                                WeatherForecast.
                                ToListAsync();

            return models;
        }
    }
}
