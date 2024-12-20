using Microsoft.AspNetCore.Authorization;

namespace WebApi.Common;

[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class AuthorizeApiControllerBase : ApiControllerBase { }
