using Application.Interfaces.Identity;
using AutoMapper;
using Domain.User;
using Domain.User.Queries;
using Domain.User.Repositories;
using Domain.User.ValueObjects;
using MediatR;
using SeedWork.Domain.ExceptionValidation;

namespace Application.Features.User.UpdateUser;

sealed internal class Handler
    (
        IMapper mapper,
        ICurrentUserService currentUser,
        IUsersRepository usersRepository
    ) : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICurrentUserService _currentUser = currentUser;
    private readonly IUsersRepository _usersRepository = usersRepository;
    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUser.GetCurrentUser();
        var user = await _usersRepository.GetUserById(currentUser.Id, cancellationToken);

        Check.IsNotNull<NullReferenceException>(user, $"El usuario con el id {currentUser.Id} no existe.");

        user.Update(DateTime.UtcNow, request.Name, request.Email);

        await _usersRepository.UpdateAsync(user, cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}
