using BizBuddy.Application.Common;
using BizBuddy.Application.Preset.Commands.CreateTenantSettings;
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
    }
}
