using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Orders.Commands.CreateOrder;
using BizBuddy.Application.Orders.Commands.DeleteOrder;
using BizBuddy.Application.Orders.Commands.UpdateOrder;
using BizBuddy.Application.Orders.Queries.GetOrderDetail;
using BizBuddy.Application.Orders.Queries.GetOrderWithPagination;
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
        [HttpPut("UpdateOrder/{id}")]
        public async Task<ActionResult<Result>> OrderUpdate(long id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<OrderDetailDto>>> GetOrderDetail(int id)
        {
            return await Mediator.Send(new GetOrderDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<OrderListDto>>>> GetOrderPagination([FromQuery] GetOrderWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
