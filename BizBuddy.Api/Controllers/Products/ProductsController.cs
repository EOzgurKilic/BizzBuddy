using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Products.Commands.CreateProducts;
using BizBuddy.Application.Products.Commands.DeleteProducts;
using BizBuddy.Application.Products.Commands.UpdateProducts;
using BizBuddy.Application.Products.Queries.GetProductsDetail;
using BizBuddy.Application.Products.Queries.GetProductsWithPagination;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<ProductsDto>>> GetProducts(int id)
        {
            return await Mediator.Send(new GetProductsDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<ProductsListDto>>>> GetProductWithPagination([FromQuery] GetProductsWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
    }
}
