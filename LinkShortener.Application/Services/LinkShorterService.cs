﻿using System.Text;
using LinkShortener.Application.Interfaces;

namespace LinkShortener.Application.Services;

public class LinkShorterService : ILinkShorterService
{
    public string GenerateShortLink(string url, int length)
    {
        var inputBytes = Encoding.UTF8.GetBytes(url);
        var keyBytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());

        var encryptedBytes = new byte[inputBytes.Length];

        for (var i = 0; i < inputBytes.Length; i++)
            encryptedBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);

        return Convert.ToBase64String(encryptedBytes)[..length];
    }
}