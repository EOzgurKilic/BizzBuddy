using BizBuddy.Application.Common;
using BizBuddy.Application.Products.Commands.CreateProducts;
using BizBuddy.Application.Products.Commands.DeleteProducts;
using BizBuddy.Application.Products.Commands.UpdateProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Products
{

    public class ProductsController : ApiControllerBase
    {
        [HttpPost("CreateProducts")]
        public async Task<ActionResult<Result<long>>> CreateProduct(CreateProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<Result>> DeleteProduct(long id)
        {
            return await Mediator.Send(new DeleteProductsCommand(id));
        }
        
          [HttpPut("UpdateProducts/{id}")]
        public async Task<ActionResult<Result>> ProductsUpdate(long id, UpdateProductsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}
