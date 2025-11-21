using BizBuddy.Application.Common;
using BizBuddy.Application.RoleAssignment.Commands.CreateRole;
using BizBuddy.Application.RoleAssignment.Commands.DeleteRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.RoleAssignment
{

    public class RoleController : ApiControllerBase
    {
        [HttpPost("CreateRoles")]
        public async Task<ActionResult<Result<long>>> CreateRole(CreateRoleCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpDelete("DeleteRole/{id}")]
        public async Task<ActionResult<Result>> DeleteRole(long id)
        {
            return await Mediator.Send(new DeleteRoleCommand(id));
        }
    }
}
