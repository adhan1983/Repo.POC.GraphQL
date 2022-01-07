using Microsoft.Extensions.DependencyInjection;
using POC.GraphQL.Repository.Repositories;
using POC.GraphQL.Service;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Interfaces.Services;

namespace POC.GraphQL.Api.Extensions
{
    public static class RegisterDependencyManager
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
