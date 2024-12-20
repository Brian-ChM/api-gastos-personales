using Domain.User;
using Domain.User.Repositories;
using Domain.User.ValueObjects;
using Infraestructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.User;

internal sealed class UsersRepository(ApplicationDbContext context) : IUsersRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(UserAd agregateRoot, CancellationToken cancellationToken)
    {
        _context.Users.Add(agregateRoot);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UserAd agregateRoot, CancellationToken cancellationToken)
    {
        _context.Users.Update(agregateRoot);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserAd?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == new UserEmail(email), cancellationToken) ??
            throw new Exception($"El usuario con el {email} no existe.");
    }

    public async Task<UserAd> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users.FindAsync(id, cancellationToken) ??
            throw new Exception($"El usuario con el id {id} no existe.");
    }
}
