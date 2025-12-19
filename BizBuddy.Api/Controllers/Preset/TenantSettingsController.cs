using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Preset.Commands.CreateTenantSettings;
using BizBuddy.Application.Preset.Commands.DeleteTenantSettings;
using BizBuddy.Application.Preset.Commands.UpdateTenantSettings;
using BizBuddy.Application.Preset.Queries.GetPresetSettingsDetail;
using BizBuddy.Application.Preset.Queries.GetTenantSettingsDetail;
using BizBuddy.Application.Preset.Queries.GetTenantSettingsWithPagination;
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

        [HttpPut("UpdateTenantSettings/{id}")]
        public async Task<ActionResult<Result>> TenantSettingsUpdate(long id, UpdateTenantSettingsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TenantSettingsDetailDto>>> GetTenantSettings(int id)
        {
            return await Mediator.Send(new GetTenantSettingsDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<TenantSettingsListDto>>>> GetTenantSettingsWithPagination([FromQuery] GetTenantSettingsWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
    }
}
