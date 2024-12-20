using MediatR;

namespace Application.Features.User.GetByName;

public record class GetUserByEmailCommand : IRequest<GetUserByEmailResponse>
{
    public string Email { get; init; } = string.Empty;
}
