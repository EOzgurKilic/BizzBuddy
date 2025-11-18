using BizBuddy.Application.Common;
using BizBuddy.Application.InventoryMoves.Commands.CreateInventoryMoves;
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
    }
}
