using BizBuddy.Application.Common;
using BizBuddy.Application.Features.Persons.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.Person
{

    public class PersonController : ApiControllerBase
    {
        // [HttpPost("CreatePerson")]
        // public async Task<ActionResult<Result<long>>> CreatePerson(CreatePersonCommand command)
        // {
        //     return await Mediator.Send(command);
        // }
    }
}
