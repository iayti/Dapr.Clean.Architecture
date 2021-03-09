using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Exceptions;
using Dapr.CleanArchitecture.Application.Common.Interfaces;
using Dapr.CleanArchitecture.Application.Common.Security;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dapr.CleanArchitecture.Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;

        public AuthorizationBehaviour(
            ILogger<TRequest> logger,
            ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (!authorizeAttributes.Any()) 
                return await next();
            
            // Must be authenticated user
            if (_currentUserService.UserId == null)
                throw new UnauthorizedAccessException();

            // User is authorized / authorization not required
            return await next();
        }
    }
}