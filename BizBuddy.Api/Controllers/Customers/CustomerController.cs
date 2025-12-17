using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Customers.Commands.CreateCustomers;
using BizBuddy.Application.Customers.Commands.DeleteCustomers;
using BizBuddy.Application.Customers.Commands.UpdateCustomers;
using BizBuddy.Application.Customers.Queries.GetCustomerDetail;
using BizBuddy.Application.Customers.Queries.GetCustomersWithPagination;
using BizBuddy.Application.Customers.Queries.GetCustomersWithPaginationQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Customers
{

    public class CustomerController : ApiControllerBase
    {
        [HttpPost("CreateCustomers")]
        public async Task<ActionResult<Result<long>>> CreateCustomer(CreateCustomersCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult<Result>> DeleteCustomer(long id)
        {

            return await Mediator.Send(new DeleteCustomersCommand(id));
        }
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<ActionResult<Result>> CustomerUpdate(long id, UpdateCustomersCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CustomersDto>>> GetCustomers(int id)
        {
            return await Mediator.Send(new GetCustomerDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<GetCustomerListDto>>>> GetCustomersWithPagination([FromQuery] GetCustomersWithPaginationQuery query)
        {

            return await Mediator.Send(query);
        }
    }
}
