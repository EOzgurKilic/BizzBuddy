using BizBuddy.Application.Common;
using BizBuddy.Application.Orders.Commands.CreateOrderItem;
using BizBuddy.Application.Orders.Commands.DeleteOrderItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Orders
{

    public class OrderItemController : ApiControllerBase
    {
        [HttpPost("CreateOrderItems")]
        public async Task<ActionResult<Result<long>>> CreateOrderItem(CreateOrderItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteOrderItem/{id}")]
        public async Task<ActionResult<Result>> DeleteOrderItem(long id)
        {
            return await Mediator.Send(new DeleteOrderItemCommand(id));
        }
    }
}
