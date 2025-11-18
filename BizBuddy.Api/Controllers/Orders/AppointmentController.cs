using BizBuddy.Application.Common;
using BizBuddy.Application.Orders.Commands.CreateAppointment;
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
    }
}
