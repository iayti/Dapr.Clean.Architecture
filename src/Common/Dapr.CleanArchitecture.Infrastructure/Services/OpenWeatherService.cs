using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Interfaces;
using Dapr.CleanArchitecture.Application.Common.Mapping;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.ExternalServices.OpenWeather.Request;
using Dapr.CleanArchitecture.Application.ExternalServices.OpenWeather.Response;
using Dapr.CleanArchitecture.Domain.Enums;

namespace Dapr.CleanArchitecture.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}