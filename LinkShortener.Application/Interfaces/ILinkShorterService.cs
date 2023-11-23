namespace LinkShortener.Application.Interfaces;

public interface ILinkShorterService
{
    public string GenerateShortLink(string url, int length);
}