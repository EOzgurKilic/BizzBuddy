using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Preset.Queries.GetTenantSettingsDetail;
using BizBuddy.Application.Preset.Queries.GetTenantSettingsWithPagination;
using BizBuddy.Application.RoleAssignment.Commands.CreateBranding;
using BizBuddy.Application.RoleAssignment.Commands.DeleteBranding;
using BizBuddy.Application.RoleAssignment.Commands.UpdateBranding;
using BizBuddy.Application.RoleAssignment.Queries.GetBrandingDetail;
using BizBuddy.Application.RoleAssignment.Queries.GetBrandingWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.RoleAssignment
{
    public class BrandingController : ApiControllerBase
    {
        [HttpPost("CreateBrandings")]
        public async Task<ActionResult<Result<long>>> CreateBranding(CreateBrandingCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteBranding/{id}")]
        public async Task<ActionResult<Result>> DeleteBranding(long id)
        {
            return await Mediator.Send(new DeleteBrandingCommand(id));
        }
        [HttpPut("UpdateBranding{id}")]
        public async Task<ActionResult<Result>> BrandingUpdate(long id, UpdateBrandingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<BrandingDto>>> GetBranding(int id)
        {
            return await Mediator.Send(new GetBrandingDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<BrandingListDto>>>> GetBrandingWithPagination([FromQuery] GetBrandingWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
            
    }
}
