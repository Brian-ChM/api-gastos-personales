using MediatR;

namespace Application.Features.User.Register;

public record RegisterUserCommand : IRequest<RegisterUserResponse>
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
