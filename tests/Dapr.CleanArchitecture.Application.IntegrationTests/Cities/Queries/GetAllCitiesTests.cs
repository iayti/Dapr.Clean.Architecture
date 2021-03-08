using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Cities.Queries.GetCities;
using Dapr.CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Dapr.CleanArchitecture.Application.IntegrationTests.Testing;

namespace Dapr.CleanArchitecture.Application.IntegrationTests.Cities.Queries
{
    public class GetAllCitiesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            await AddAsync(new City
            {
                Name = "Manisa",
            });

            var query = new GetAllCitiesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Count.Should().BeGreaterThan(0);
        }
    }
}