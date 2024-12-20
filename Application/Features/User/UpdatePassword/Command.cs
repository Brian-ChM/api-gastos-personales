using MediatR;

namespace Application.Features.User.UpdatePassword;

public record UpdatePasswordCommand : IRequest<string>
{
    public string Email { get; init; } = string.Empty;
    public string OldPassword { get; init; } = string.Empty;
    public string NewPassword { get; init; } = string.Empty;
}
