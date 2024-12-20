namespace Application.Interfaces.Identity.Response;

public class CurrentUser
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
}
