using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Orders.Commands.CreateOrderItem;
using BizBuddy.Application.Orders.Commands.DeleteOrderItem;
using BizBuddy.Application.Orders.Commands.UpdateOrderItem;
using BizBuddy.Application.Orders.Queries.GetOrderDetail;
using BizBuddy.Application.Orders.Queries.GetOrderItemDetail;
using BizBuddy.Application.Orders.Queries.GetOrderItemWithPagination;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<OrderItemDetailDto>>> GetOrderItemDetail(int id)
        {
            return await Mediator.Send(new GetOrderItemQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<OrderItemListDto>>>> GetOrderItemPagination([FromQuery] GetOrderItemWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
