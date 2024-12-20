using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;
    private IMapper? _mapper;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>() ?? throw new Exception("Mediator is required.");
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>() ?? throw new Exception("Mapper is required.");
}
