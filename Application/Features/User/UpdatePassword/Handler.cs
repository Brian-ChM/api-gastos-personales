using Application.Features.User.UpdatePassword;
using Application.Interfaces;
using Domain.User.Queries;
using Domain.User.Repositories;
using MediatR;

namespace Application.Features.User.Update;

sealed internal class UpdatePasswordHandler
    (
        IPasswordEncryptor passwordEncryptor,
        IUsersRepository usersRepository
    ) : IRequestHandler<UpdatePasswordCommand, string>
{
    private readonly IPasswordEncryptor _passwordEncryptor = passwordEncryptor;
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<string> Handle(UpdatePasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetUserByEmail(command.Email, cancellationToken);

        if (!_passwordEncryptor.VerifyPassword(command.OldPassword, user!.Password))
            throw new Exception("Las contraseña anterior es incorrecta.");

        var passwordEncrypt = _passwordEncryptor.EncryptPassword(command.NewPassword);

        user.Password = passwordEncrypt;
        await _usersRepository.UpdateAsync(user, cancellationToken);
        return "Contraseña actualizada correctamente!";
    }
}
