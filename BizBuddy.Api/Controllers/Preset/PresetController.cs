using BizBuddy.Application.Common;
using BizBuddy.Application.Preset.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Preset
{
 
    public class PresetController  : ApiControllerBase
    {
        [HttpPost("CreatePresetSettings")]
        public async Task<ActionResult<Result<long>>> CreatePresetSetting(CreatePresetSettingsCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
