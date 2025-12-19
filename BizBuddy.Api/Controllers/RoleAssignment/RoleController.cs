using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.RoleAssignment.Commands.CreateRole;
using BizBuddy.Application.RoleAssignment.Commands.DeleteRole;
using BizBuddy.Application.RoleAssignment.Commands.UpdateRole;
using BizBuddy.Application.RoleAssignment.Queries.GetRoleDetail;
using BizBuddy.Application.RoleAssignment.Queries.GetRoleWithPagination;
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
        [HttpPut("UpdateRole{id}")]
        public async Task<ActionResult<Result>> RoleUpdate(long id, UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<RoleDto>>> GetRole(int id)
        {
            return await Mediator.Send(new GetRoleDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<RoleListDto>>>> GetRoleWithPagination([FromQuery] GetRoleWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
