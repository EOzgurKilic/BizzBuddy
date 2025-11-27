using BizBuddy.Application.Common;
using BizBuddy.Application.Orders.Commands.CreateAppointment;
using BizBuddy.Application.Orders.Commands.DeleteAppointment;
using BizBuddy.Application.Orders.Commands.UpdateAppointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Orders
{

    public class AppointmentController : ApiControllerBase
    {
        [HttpPost("CreateAppointments")]
        public async Task<ActionResult<Result<long>>> CreateAppointment(CreateAppointmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteAppointment/{id}")]
        public async Task<ActionResult<Result>> DeleteAppointment(long id)
        {
            return await Mediator.Send(new DeleteAppointmentCommand(id));
        }
        
        [HttpPut("UpdateAppointment/{id}")]
        public async Task<ActionResult<Result>> AppointmentUpdate(long id, UpdateAppointmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}
