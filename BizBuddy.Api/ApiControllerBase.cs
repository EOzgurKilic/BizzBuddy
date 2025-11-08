using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BizBuddy.Api.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        // Controller içinde property olarak Mediator kullanabilirsin
        protected ISender Mediator => HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
