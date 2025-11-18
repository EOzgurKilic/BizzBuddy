using BizBuddy.Application.Common;
using BizBuddy.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers.User
{

    public class UserController : ApiControllerBase
    {
        [HttpPost("CreatUsers")]
        public async Task<ActionResult<Result<long>>> CreatUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
