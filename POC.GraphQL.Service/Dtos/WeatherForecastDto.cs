﻿using System;

namespace POC.GraphQL.Service.Dtos
{
    public class WeatherForecastDto
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}
