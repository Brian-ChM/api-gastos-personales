namespace Application.Features.User.UpdateUser;

public record UpdateUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsDelete { get; set; }
}