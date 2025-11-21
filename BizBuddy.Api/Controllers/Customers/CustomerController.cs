using BizBuddy.Application.Common;
using BizBuddy.Application.Customers.Commands.CreateCustomers;
using BizBuddy.Application.Customers.Commands.DeleteCustomers;
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
    }
}
