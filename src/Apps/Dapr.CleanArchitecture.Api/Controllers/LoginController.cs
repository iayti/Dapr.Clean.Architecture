using System.Threading.Tasks;
using Dapr.CleanArchitecture.Application.ApplicationUser.Queries.GetToken;
using Dapr.CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.CleanArchitecture.Api.Controllers
{
    public class LoginController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Create(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
