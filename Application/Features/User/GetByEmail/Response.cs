namespace Application.Features.User.GetByName;

public record GetUserByEmailResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
