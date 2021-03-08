using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.Districts.Commands.Create;
using Dapr.CleanArchitecture.Application.Districts.Queries;
using Dapr.CleanArchitecture.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.CleanArchitecture.Api.Controllers
{
    [Authorize]
    public class DistrictsController: BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportDistrictsQuery { CityId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<DistrictDto>>> Create(CreateDistrictCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
