using Domain.User.Queries;
using Domain.User.Queries.Response;
using Domain.User.ValueObjects;
using Infraestructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Queries.User;

internal sealed class UsersQueries(ApplicationDbContext context) : IUsersQueries
{
    private readonly ApplicationDbContext _context = context;

    public async Task<GetUserByEmailQueryResponse> GetUserByEmailQuery(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == new UserEmail(email), cancellationToken) ??
            throw new Exception($"El usuario con el email {email} no existe.");

        var response = new GetUserByEmailQueryResponse
        {
            Id = user.Id,
            Name = user.Name.Value,
            Email = user.Email.Value,
            CreatedAt = user.CreatedDate,
            UpdatedAt = user.UpdatedDate,
        };

        return response;
    }
}
