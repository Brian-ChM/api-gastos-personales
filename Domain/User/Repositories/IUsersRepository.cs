namespace Domain.User.Repositories;

public interface IUsersRepository
{
    Task AddAsync(UserAd agregateRoot, CancellationToken cancellationToken);
    Task UpdateAsync(UserAd agregateRoot, CancellationToken cancellationToken);
    Task<UserAd?> GetUserByEmail(string email, CancellationToken cancellationToken);
    Task<UserAd> GetUserById(Guid id, CancellationToken cancellationToken);
}
