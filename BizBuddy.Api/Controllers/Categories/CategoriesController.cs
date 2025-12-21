using BizBuddy.Application.Categories.Commands.CreateCategories;
using BizBuddy.Application.Categories.Commands.DeleteCategories;
using BizBuddy.Application.Categories.Commands.UpdateCategories;
using BizBuddy.Application.Categories.Queries.GetCategoriesDetail;
using BizBuddy.Application.Categories.Queries.GetCategoriesWithPagination;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Categories
{

    public class CategoriesController : ApiControllerBase
    {
             [HttpPost("CreateCategories")]
        public async Task<ActionResult<Result<long>>> CreateCategorie(CreateCategoriesCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteCategorie/{id}")]
        public async Task<ActionResult<Result>> DeleteCategories(long id)
        {

            return await Mediator.Send(new DeleteCategoriesCommand(id));
        }
        [HttpPut("UpdateCategories/{id}")]
        public async Task<ActionResult<Result>> CustomerCategorie(long id, UpdateCategoriesCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CategoriesDto>>> GetCategories(int id)
        {
            return await Mediator.Send(new GetCategoriesDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<CategoriesDtoList>>>> GetCategoriesWithPagination([FromQuery] GetCategoriesWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
    }
}
