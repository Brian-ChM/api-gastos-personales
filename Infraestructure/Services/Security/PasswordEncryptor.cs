using Application.Interfaces;

namespace Infraestructure.Services.Security;


public class PasswordEncryptor : IPasswordEncryptor
{
    public string EncryptPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}

