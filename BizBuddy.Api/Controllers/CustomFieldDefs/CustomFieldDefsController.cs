using BizBuddy.Application.Common;
using BizBuddy.Application.CustomFieldDefs.Commands.CreateCustomFieldDefs;
using BizBuddy.Application.CustomFieldDefs.Commands.DeleteCustomFieldDefs;
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
    }
}
