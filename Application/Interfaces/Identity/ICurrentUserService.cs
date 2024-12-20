using Application.Interfaces.Identity.Response;

namespace Application.Interfaces.Identity;

public interface ICurrentUserService
{
    bool IsAuthenticated { get; }
    CurrentUser GetCurrentUser();
}
