using MediatR;

namespace Application.Features.User.Login;

public record class LoginCommand : IRequest<string>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
