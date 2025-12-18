using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Orders.Commands.CreateAppointment;
using BizBuddy.Application.Orders.Commands.DeleteAppointment;
using BizBuddy.Application.Orders.Commands.UpdateAppointment;
using BizBuddy.Application.Orders.Queries.GetAppointmentDetail;
using BizBuddy.Application.Orders.Queries.GetAppointmentWithPagination;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AppointmentDetailDto>>> GetAppointmentDetail(int id)
        {
            return await Mediator.Send(new GetAppointmentDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<AppointmentListDto>>>> GetAppointmentPagination([FromQuery] GetAppointmentWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
