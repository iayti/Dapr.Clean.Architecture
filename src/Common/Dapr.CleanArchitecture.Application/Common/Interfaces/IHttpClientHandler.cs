using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Domain.Enums;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}