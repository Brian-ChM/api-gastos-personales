using System.Security.Claims;
using Application.Interfaces.Identity;
using Application.Interfaces.Identity.Response;
using Microsoft.AspNetCore.Http;

namespace Infraestructure.Services.Identity;

internal class CurrentUserService
    (
        IHttpContextAccessor httpContextAccessor
    ) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public CurrentUser GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user is null || !IsAuthenticated)
            throw new UnauthorizedAccessException("There is no user logged in");

        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var name = user.FindFirstValue(ClaimTypes.Name);
        var role = user.FindFirstValue(ClaimTypes.Role);

#nullable disable
        var response = new CurrentUser()
        {
            Id = Guid.Parse(userId),
            Name = name,
            Role = role
        };
#nullable enable

        return response;
    }
}
