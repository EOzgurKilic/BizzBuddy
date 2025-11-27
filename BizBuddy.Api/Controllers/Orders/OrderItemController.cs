using BizBuddy.Application.Common;
using BizBuddy.Application.Orders.Commands.CreateOrderItem;
using BizBuddy.Application.Orders.Commands.DeleteOrderItem;
using BizBuddy.Application.Orders.Commands.UpdateOrderItem;
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

        [HttpPut("UpdateOrderItem/{id}")]
        public async Task<ActionResult<Result>> OrderItemUpdate(long id, UpdateOrderItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}
