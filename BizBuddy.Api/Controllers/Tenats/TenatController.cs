using BizBuddy.Application.Common;
using BizBuddy.Application.Tenat.Commands.CreateTenat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Tenats
{
 
    public class TenatController : ApiControllerBase
    {
        [HttpPost("CreatTenat")]
        public async Task<ActionResult<Result<long>>> CreatTenat(CreateTenatCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
