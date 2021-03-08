using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Cities.Commands.Create;
using Dapr.CleanArchitecture.Application.Cities.Commands.Delete;
using Dapr.CleanArchitecture.Application.Cities.Commands.Update;
using Dapr.CleanArchitecture.Application.Cities.Queries.GetCities;
using Dapr.CleanArchitecture.Application.Cities.Queries.GetCityById;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.CleanArchitecture.Api.Controllers
{
    [Authorize]
    public class CitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<CityDto>>>> GetAllCities(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCitiesQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> GetCityById(int id)
        {
            return Ok(await Mediator.Send(new GetCityByIdQuery { CityId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<CityDto>>> Create(CreateCityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<CityDto>>> Update(UpdateCityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }));
        }
    }
}
