using BizBuddy.Application.Common;
using BizBuddy.Application.Preset.Commands;
using BizBuddy.Application.Preset.Commands.DeletePreesetSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Preset
{

    public class PresetController : ApiControllerBase
    {
        [HttpPost("CreatePresetSettings")]
        public async Task<ActionResult<Result<long>>> CreatePresetSetting(CreatePresetSettingsCommand command)
        {
            return await Mediator.Send(command);
        }
        
         [HttpDelete("DeletePresetSetting/{id}")]
        public async Task<ActionResult<Result>> DeletePresetSetting(long id)
        {
            return await Mediator.Send(new DeletePreesetSettingsCommand(id));
        }
    }
}
