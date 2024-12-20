using Application.Interfaces;
using Application.Interfaces.Identity;
using Domain.User.Repositories;
using MediatR;

namespace Application.Features.User.Login;

sealed internal class LoginHandler
    (
        IUserAuthService userAuthService,
        IPasswordEncryptor passwordEncryptor,
        IUsersRepository usersRepository
    ) : IRequestHandler<LoginCommand, string>
{
    private readonly IUserAuthService _userAuthService = userAuthService;
    private readonly IPasswordEncryptor _passwordEncryptor = passwordEncryptor;
    private readonly IUsersRepository _usersRespository = usersRepository;

    public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _usersRespository.GetUserByEmail(command.Email, cancellationToken);

        if (!_passwordEncryptor.VerifyPassword(command.Password, user!.Password))
            throw new Exception($"Contraseña incorrecta.");

        return _userAuthService.LoginAsync(user);
    }
}
