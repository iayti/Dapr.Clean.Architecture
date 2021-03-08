using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Cities.Commands.Create;
using Dapr.CleanArchitecture.Application.Common.Behaviours;
using Dapr.CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Dapr.CleanArchitecture.Application.UnitTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreateCityCommand>> _logger;
        private readonly Mock<ICurrentUserService> _currentUserService;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreateCityCommand>>();

            _currentUserService = new Mock<ICurrentUserService>();
        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns("Administrator");

            var requestLogger = new LoggingBehaviour<CreateCityCommand>(_logger.Object, _currentUserService.Object);

            await requestLogger.Process(new CreateCityCommand { Name = "Bursa" }, new CancellationToken());
        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new LoggingBehaviour<CreateCityCommand>(_logger.Object, _currentUserService.Object);

            await requestLogger.Process(new CreateCityCommand { Name = "Bursa" }, new CancellationToken());
        }
    }
}
