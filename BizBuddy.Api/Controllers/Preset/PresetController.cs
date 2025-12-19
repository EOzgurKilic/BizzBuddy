using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Preset.Commands;
using BizBuddy.Application.Preset.Commands.DeletePreesetSettings;
using BizBuddy.Application.Preset.Commands.UpdatePreset;
using BizBuddy.Application.Preset.Queries.GetPresetSettingsDetail;
using BizBuddy.Application.Preset.Queries.GetPresetSettingsWithPagination;
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
        [HttpPut("UpdatePreset/{id}")]
        public async Task<ActionResult<Result>> UpdatePreset(long id, UpdatePresetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<PresetSettingsDetailDto>>> GetPresetSettings(int id)
        {
            return await Mediator.Send(new GetPresetSettingsDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<PresetSettingsListDto>>>> GetPresetSettingsWithPagination([FromQuery] GetPresetSettingsWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
    }
}
