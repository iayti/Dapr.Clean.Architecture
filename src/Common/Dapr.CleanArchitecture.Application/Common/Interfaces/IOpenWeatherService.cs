using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.ExternalServices.OpenWeather.Request;
using Dapr.CleanArchitecture.Application.ExternalServices.OpenWeather.Response;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}