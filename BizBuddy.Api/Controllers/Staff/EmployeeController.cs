using BizBuddy.Application.Common;
using BizBuddy.Application.Staff.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Staff
{
 
    public class EmployeeController : ApiControllerBase
    {
        [HttpPost("CreateEmployees")]
        public async Task<ActionResult<Result<long>>> CreateEmployee(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
