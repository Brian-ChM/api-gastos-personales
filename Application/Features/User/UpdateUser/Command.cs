using MediatR;

namespace Application.Features.User.UpdateUser;

public record UpdateUserCommand : IRequest<UpdateUserResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsDelete { get; set; }
}
