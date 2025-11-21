using BizBuddy.Application.Common;
using BizBuddy.Application.Orders.Commands.CreatePayment;
using BizBuddy.Application.Orders.Commands.DeletePayment;
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
    }
}
