using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.InventoryMoves.Commands.CreateInventoryMoves;
using BizBuddy.Application.InventoryMoves.Commands.DeleteInventoryMoves;
using BizBuddy.Application.InventoryMoves.Commands.UpdateInventoryMoves;
using BizBuddy.Application.InventoryMoves.Queries.GetInventoryMovesDetail;
using BizBuddy.Application.InventoryMoves.Queries.GetInventoryMovesWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.InventoryMoves
{

    public class InventoryMovesController : ApiControllerBase
    {
        [HttpPost("CreateInventoryMoves")]
        public async Task<ActionResult<Result<long>>> CreateInventoryMove(CreateInventoryMovesCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteInventoryMove/{id}")]
        public async Task<ActionResult<Result>> DeleteInventoryMove(long id)
        {
            return await Mediator.Send(new DeleteInventoryMovesCommand(id));
        }

        [HttpPut("UpdateInventoryMoves/{id}")]
        public async Task<ActionResult<Result>> InventoryMovesUpdate(long id, UpdateInventoryMovesCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<InventoryMovesDetailDto>>> GetInventoryMovesDetail(int id)
        {
            return await Mediator.Send(new GetInventoryMovesDetailQuery(id));
        }
         [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<InventoryMovesListDto>>>> GetInventoryMovesPagination([FromQuery] GetInventoryMovesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
        
    }
}
