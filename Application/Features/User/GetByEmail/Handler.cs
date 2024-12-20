using AutoMapper;
using Domain.User.Queries;
using MediatR;

namespace Application.Features.User.GetByName;

sealed internal class GetUserByEmailHandler
    (
        IUsersQueries userQueries,
        IMapper mapper
    ) : IRequestHandler<GetUserByEmailCommand, GetUserByEmailResponse>
{
    private readonly IUsersQueries _usersQueries = userQueries;
    private readonly IMapper _mapper = mapper;

    public async Task<GetUserByEmailResponse> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
    {
        var rawAd = await _usersQueries.GetUserByEmailQuery(request.Email, cancellationToken);
        var respondeAds = _mapper.Map<GetUserByEmailResponse>(rawAd);

        return respondeAds;
    }
}
