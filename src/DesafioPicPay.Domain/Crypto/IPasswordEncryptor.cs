namespace DesafioPicPay.Infrastructure.Crypto;

public interface IPasswordEncryptor
{
    string Encrypt(string password);
    bool Verify(string password, string encryptedPassword);
}