using System.Security.Cryptography;
using System.Text;

namespace FinanceControl.Application.Services.Cryptography;

public class PasswordEncrypter
{
    public string Encrypt(string password)
    { 
      var additionalkey = "ABC";
      var newPassword = $"{password}{additionalkey}";  
      var bytes = Encoding.UTF8.GetBytes(newPassword);
      var hashBytes = SHA512.HashData(bytes);
      return StringBytesToString(hashBytes);
    }

    private static string StringBytesToString(byte[] bytes)
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