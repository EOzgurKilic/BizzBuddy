using BizBuddy.Application.Common;
using BizBuddy.Application.Customers.Commands.CreateCustomers;
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
    }
}
