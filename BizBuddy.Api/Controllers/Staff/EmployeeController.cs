using BizBuddy.Application.Common;
using BizBuddy.Application.Staff.Commands;
using BizBuddy.Application.Staff.Commands.DeleteEmployee;
using BizBuddy.Application.Staff.Commands.UpdateEmployee;
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

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<Result>> DeleteEmployee(long id)
        {
            return await Mediator.Send(new DeleteEmployeeCommand(id));
        }
        [HttpPut("UpdateEmployee{id}")]
        public async Task<ActionResult<Result>> EmployeeUpdate(long id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}
