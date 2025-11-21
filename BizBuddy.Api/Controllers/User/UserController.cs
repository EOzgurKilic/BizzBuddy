using BizBuddy.Application.Common;
using BizBuddy.Application.Users.Commands.CreateUser;
using BizBuddy.Application.Users.Commands.DeleteUser;
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

         [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<Result>> DeleteUser(long id)
        {
            return await Mediator.Send(new DeleteUserCommand(id));
        }
    }
}
