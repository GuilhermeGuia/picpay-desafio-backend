using System.Security.Cryptography;
using System.Text;

namespace DesafioPicPay.Infrastructure.Crypto;

public class PasswordEncryptor : IPasswordEncryptor
{
    private readonly string _key;
    public PasswordEncryptor() => _key = "PAITINHO";
    public PasswordEncryptor(string key) => _key = key;
    public string Encrypt(string input)
    {
        var newPassword = $"{input}{_key}";

        var bytes = Encoding.UTF8.GetBytes(newPassword);
        var hashBytes = SHA512.HashData(bytes);

        return StringBytes(hashBytes);
    }

    public bool Verify(string password, string encryptedPassword)
    {
        var cryptPassowrd = Encrypt(password);

        return cryptPassowrd == encryptedPassword;
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}