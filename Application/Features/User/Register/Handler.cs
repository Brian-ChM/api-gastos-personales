using Application.Interfaces;
using AutoMapper;
using Domain.User;
using Domain.User.Repositories;
using MediatR;
using SeedWork.Domain.ExceptionValidation;

namespace Application.Features.User.Register;

sealed internal class RegisterUserHandler
    (
        IPasswordEncryptor passwordEncryptor,
        IUsersRepository usersRepository,
        IMapper mapper
    ) : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordEncryptor _passwordEncryptor = passwordEncryptor;
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        Check.That<ArgumentOutOfRangeException>((!(command.Password.Length >= 40)), "Password is too long.");
        
        var passwordEncryptor = _passwordEncryptor.EncryptPassword(command.Password);
        
        var registerAd = new UserAd(command.Name, command.Email, passwordEncryptor, DateTime.UtcNow);
        await _usersRepository.AddAsync(registerAd, cancellationToken);
        return _mapper.Map<RegisterUserResponse>(registerAd);
    }
}
