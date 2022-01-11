using Microsoft.Extensions.DependencyInjection;
using POC.GraphQL.Repository.Repositories;
using POC.GraphQL.Service;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Interfaces.Services;
using POC.GraphQL.Service.Services;

namespace POC.GraphQL.Api.Extensions
{
    public static class RegisterDependencyManager
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();

        }
    }
}
