using GraphQL.Types;
using POC.GraphQL.Service.Dtos;

namespace POC.GraphQL.Api.GraphQL.GraphQLTypes
{
    public class WeatherForecastType : ObjectGraphType<WeatherForecastDto>
    {
        public WeatherForecastType()
        {
            Field(x => x.TemperatureC, type: typeof(IdGraphType)).Description("The TemperatureC from the WeatherForecastDto.");
            Field(x => x.Summary).Description("Summary property from the WeatherForecastDto object.");
            Field(x => x.TemperatureF).Description("TemperatureF property from the WeatherForecastDto object.");
            Field(x => x.Date.Date, type: typeof(DateGraphType)).Description("TemperatureF property from the WeatherForecastDto object.");
        }
    }
}
