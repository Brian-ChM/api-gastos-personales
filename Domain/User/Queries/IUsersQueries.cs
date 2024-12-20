using Domain.User.Queries.Response;

namespace Domain.User.Queries;

public interface IUsersQueries
{
    public Task<GetUserByEmailQueryResponse> GetUserByEmailQuery(string email, CancellationToken cancellationToken);
}
