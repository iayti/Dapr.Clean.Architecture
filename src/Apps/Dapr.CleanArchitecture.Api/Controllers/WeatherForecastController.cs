using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.Dto;
using Dapr.CleanArchitecture.Application.WeatherForecasts.Queries.GetCurrentWeatherForecastQuery;
using Dapr.CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecastQuery;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.CleanArchitecture.Api.Controllers
{
    public class WeatherForecastController : BaseApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }

        [HttpGet("current")]
        public async Task<ActionResult<ServiceResult<CurrentWeatherForecastDto>>> GetCurrentWeather([FromQuery] GetCurrentWeatherForecastQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
