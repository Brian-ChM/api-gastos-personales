namespace Application.Interfaces;

public interface IPasswordEncryptor
{
    string EncryptPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
