using System.Globalization;
using System.Text;

namespace LinkShortener.Services;

public class LinkShorterService
{
    public string GenerateShortLink(string url, int length)
    {
        var inputBytes = Encoding.UTF8.GetBytes(url);
        var keyBytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());

        var encryptedBytes = new byte[inputBytes.Length];

        for (var i = 0; i < inputBytes.Length; i++)
            encryptedBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
        
        var limitedBytes = new byte[length];
        Array.Copy(encryptedBytes, encryptedBytes.Length - length, 
            limitedBytes, 0, length);

        return Convert.ToBase64String(limitedBytes);
    }
}