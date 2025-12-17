using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizBuddy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected ISender Mediator =>
        HttpContext.RequestServices.GetRequiredService<ISender>();
}
