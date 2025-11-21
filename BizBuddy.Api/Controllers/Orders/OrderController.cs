using BizBuddy.Application.Common;
using BizBuddy.Application.Orders.Commands.CreateOrder;
using BizBuddy.Application.Orders.Commands.DeleteOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Orders
{


    public class OrderController : ApiControllerBase
    {
        [HttpPost("CreateOrders")]
        public async Task<ActionResult<Result<long>>> CreateOrder(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<ActionResult<Result>> DeleteOrder(long id)
        {
            return await Mediator.Send(new DeleteOrderCommand(id));
        }
    }
}
