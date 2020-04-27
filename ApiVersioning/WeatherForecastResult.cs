using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVersioning
{
    public class WeatherForecastResult
    {
        public string ApiVersion { get; set; }
        public WeatherForecast[] WeatherForecasts { get; set; }
    }
}
