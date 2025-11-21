using BizBuddy.Application.Common;
using BizBuddy.Application.Preset.Commands.CreateTenantSettings;
using BizBuddy.Application.Preset.Commands.DeleteTenantSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Preset
{

    public class TenantSettingsController : ApiControllerBase
    {
        [HttpPost("CreateTenantSettings")]
        public async Task<ActionResult<Result<long>>> CreateTenantSetting(CreateTenantSettingsCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpDelete("DeleteTenantSetting/{id}")]
        public async Task<ActionResult<Result>> DeleteTenantSetting(long id)
        {
            return await Mediator.Send(new DeleteTenantSettingsCommand(id));
        }
    }
}
