using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Users.Commands.CreateUser;
using BizBuddy.Application.Users.Commands.DeleteUser;
using BizBuddy.Application.Users.Commands.UpdateUsers;
using BizBuddy.Application.Users.Queries.GetUsersDetail;
using BizBuddy.Application.Users.Queries.GetUserWithPagination;
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

        [HttpPut("UpdateUser{id}")]
        public async Task<ActionResult<Result>> UserUpdate(long id, UpdateUsersCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
           [HttpGet("{id}")]
        public async Task<ActionResult<Result<UsersDto>>> GetUser(int id)
        {
            return await Mediator.Send(new GetUsersDetailQuery(id));
        }
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<UserListDto>>>> GetUserWithPagination([FromQuery] GetUserWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
