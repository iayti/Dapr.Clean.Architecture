using System;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Cities.Commands.Create;
using Dapr.CleanArchitecture.Application.Common.Exceptions;
using Dapr.CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Dapr.CleanArchitecture.Application.IntegrationTests.Testing;

namespace Dapr.CleanArchitecture.Application.IntegrationTests.Cities.Commands
{
    public class CreateCityTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateCityCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();

        }

        [Test]
        public async Task ShouldRequireUniqueName()
        {
            await SendAsync(new CreateCityCommand
            {
                Name = "Bursa"
            });

            var command = new CreateCityCommand
            {
                Name = "Bursa"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCity()
        {
            var command = new CreateCityCommand
            {
                Name = "Kastamonu"
            };

            var result = await SendAsync(command);

            var list = await FindAsync<City>(result.Data.Id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
            list.CreateDate.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
