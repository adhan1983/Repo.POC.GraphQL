using GraphQL.Types;
using POC.GraphQL.Api.GraphQL.GraphQLTypes;
using POC.GraphQL.Service.Interfaces.Services;

namespace POC.GraphQL.Api.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IStudentService studentService, IWeatherForecastService weatherForecastService)
        {
            Field<ListGraphType<StudentType>>(
                "students",
                resolve: context => studentService.GetStudentAllAsync()
            );

            Field<ListGraphType<WeatherForecastType>>(
                "weatherForecastTypes",
                resolve: context => weatherForecastService.GetAllWeatherForecastAsync()
            );
        }
    }
}
