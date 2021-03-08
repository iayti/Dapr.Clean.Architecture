using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.Common.Models;
using Dapr.CleanArchitecture.Application.Dto;
using Dapr.CleanArchitecture.Application.Villages.Queries.GetVillagesWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.CleanArchitecture.Api.Controllers
{
    [Authorize]
    public class VillagesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<PaginatedList<VillageDto>>>> GetAllVillagesWithPagination(GetAllVillagesWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
