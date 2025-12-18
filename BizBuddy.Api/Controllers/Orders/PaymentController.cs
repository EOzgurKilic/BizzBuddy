using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Orders.Commands.CreatePayment;
using BizBuddy.Application.Orders.Commands.DeletePayment;
using BizBuddy.Application.Orders.Commands.UpdatePayment;
using BizBuddy.Application.Orders.Queries.GetPaymentDetail;
using BizBuddy.Application.Orders.Queries.GetPaymentWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Orders
{

    public class PaymentController : ApiControllerBase
    {
        [HttpPost("CreatePayments")]
        public async Task<ActionResult<Result<long>>> CreatePayment(CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpDelete("DeletePayment/{id}")]
        public async Task<ActionResult<Result>> DeletePayment(long id)
        {
            return await Mediator.Send(new DeletePaymentCommand(id));
        }
        [HttpPut("UpdatePayment/{id}")]
        public async Task<ActionResult<Result>> PaymentUpdate(long id, UpdatePaymentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<Result<PaymentDetailDto>>> GetPaymentDetail(int id)
        {
            return await Mediator.Send(new GetPaymentDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<PaymentListDto>>>> GetPaymentPagination([FromQuery] GetPaymentWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
