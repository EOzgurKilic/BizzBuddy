using BizBuddy.Application.Common;
using BizBuddy.Application.RoleAssignment.Commands.CreateBranding;
using BizBuddy.Application.RoleAssignment.Commands.DeleteBranding;
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
    }
}
