using System;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Cities.Commands.Create;
using Dapr.CleanArchitecture.Application.Common.Exceptions;
using Dapr.CleanArchitecture.Application.Common.Security;
using Dapr.CleanArchitecture.Application.Districts.Commands.Create;
using Dapr.CleanArchitecture.Application.Districts.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Dapr.CleanArchitecture.Application.IntegrationTests.Districts.Queries
{
    using static Testing;

    public class ExportDistrictsTests : TestBase
    {
        [Test]
        public void ShouldDenyAnonymousUser()
        {
            var query = new ExportDistrictsQuery();

            query.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

            FluentActions.Invoking(() =>
                SendAsync(query)).Should().Throw<UnauthorizedAccessException>();
        }

        [Test]
        public async Task ShouldDenyNonAdministrator()
        {
            await RunAsDefaultUserAsync();

            var query = new ExportDistrictsQuery();

            FluentActions.Invoking(() =>
                SendAsync(query)).Should().Throw<ForbiddenAccessException>();
        }

        [Test]
        public async Task ShouldAllowAdministrator()
        {
            await RunAsAdministratorAsync();

            var city = await SendAsync(new CreateCityCommand
            {
                Name = "Çanakkale"
            });

            var result = await SendAsync(new CreateDistrictCommand
            {
                Name = "Çan",
                CityId = city.Data.Id
            });

            var query = new ExportDistrictsQuery
            {
                CityId = result.Data.Id
            };

            FluentActions.Invoking(() => SendAsync(query))
                .Should().NotThrow<ForbiddenAccessException>();
        }
    }
}
