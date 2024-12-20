using Domain.User;

namespace Application.Interfaces.Identity;

public interface IUserAuthService
{
    string LoginAsync(UserAd user);
}
