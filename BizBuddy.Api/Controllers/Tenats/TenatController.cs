using BizBuddy.Application.Common;
using BizBuddy.Application.Tenat.Commands.CreateTenat;
using BizBuddy.Application.Tenat.Commands.DeleteTenant;
using BizBuddy.Application.Tenat.Commands.UpdateTenant;
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
        [HttpDelete("DeleteTenant/{id}")]
        public async Task<ActionResult<Result>> DeleteTenant(long id)
        {
            return await Mediator.Send(new DeleteTenantCommand(id));
        }
              [HttpPut("UpdateTenant{id}")]
        public async Task<ActionResult<Result>> TenantUpdate(long id, UpdateTenantCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}
