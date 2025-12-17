using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.CustomFieldDefs.Commands.CreateCustomFieldDefs;
using BizBuddy.Application.CustomFieldDefs.Commands.DeleteCustomFieldDefs;
using BizBuddy.Application.CustomFieldDefs.Commands.UpdateCustomFieldDefs;
using BizBuddy.Application.CustomFieldDefs.Queries.GetCustomFieldDefsDetail;
using BizBuddy.Application.CustomFieldDefs.Queries.GetGetCustomFieldDefsWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.CustomFieldDefs
{

    public class CustomFieldDefsController : ApiControllerBase
    {
        [HttpPost("CreateCustomFieldDefs")]
        public async Task<ActionResult<Result<long>>> CreateCustomFieldDef(CreateCustomFieldDefsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteCustomFieldDef/{id}")]
        public async Task<ActionResult<Result>> DeleteCustomFieldDef(long id)
        {

            return await Mediator.Send(new DeleteCustomFieldDefsCommand(id));
        }
        [HttpPut("UpdateCustomFieldDef/{id}")]
        public async Task<ActionResult<Result>> CustomFieldDefUpdate(long id, UpdateCustomFieldDefsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
          [HttpGet("{id}")]
        public async Task<ActionResult<Result<CustomFieldDefsDetailDto>>> GetCustomFieldDefs(int id)
        {
            return await Mediator.Send(new GetCustomFieldDefsDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<CustomFieldDefsListDto>>>> GetCustomFieldDefsWithPagination([FromQuery] GetGetCustomFieldDefsWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
    }
}
