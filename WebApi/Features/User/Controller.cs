using Application.Features.User.Login;
using Application.Features.User.Register;
using Application.Features.User.UpdatePassword;
using Application.Features.User.UpdateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.Features.User.Requests;

namespace WebApi.Features.User;

public sealed class UsersController : ApiControllerBase
{
    [HttpPost]
    [Route("auth")]
    [Produces("text/plain")]
    public async Task<ActionResult<string>> UserAuth([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = Mapper.Map<LoginCommand>(request);
        var response = await Mediator.Send(command, cancellationToken);
        return response;
    }
    
    //[HttpGet]
    //[Route("getByEmail/{email}")]
    //[Produces("application/json")]
    //[Authorize(Roles = "user")]
    //public async Task<ActionResult<GetUserByEmailResponse>> GetUserByEmail([FromRoute] string email, CancellationToken cancellationToken)
    //{
    //    var response = await Mediator.Send(new GetUserByEmailCommand() { Email = email }, cancellationToken);
    //    return Mapper.Map<GetUserByEmailResponse>(response);
    //}

    [HttpPost]
    [Route("register")]
    [Produces("application/json")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var command = Mapper.Map<RegisterUserCommand>(request);
        var response = await Mediator.Send(command, cancellationToken);
        return response;
    }

    [HttpPut]
    [Route("update-password")]
    [Produces("application/json")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<string>> UpdatePassword([FromBody] UpdatePasswordUserRequest request, CancellationToken cancellationToken)
    {
        var command = Mapper.Map<UpdatePasswordCommand>(request);
        var response = await Mediator.Send(command, cancellationToken);
        return response;
    }

    [HttpPut]
    [Route("update-user")]
    [Produces("application/json")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<UpdateUserResponse>> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var command = Mapper.Map<UpdateUserCommand>(request);
        var response = await Mediator.Send(command, cancellationToken);
        return response;
    }
}
