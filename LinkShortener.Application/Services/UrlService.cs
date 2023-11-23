using LinkShortener.Application.Interfaces;
using LinkShortener.Data.Entities;
using LinkShortener.Data.Interfaces;

namespace LinkShortener.Application.Services;

public class UrlService(IRepository<Url> urlRepository,
    ILinkShorterService linkShorterService) : IUrlService
{
    public void Add(Url url)
    {
        url.ShortenedUrl = linkShorterService.GenerateShortLink(url.LongUrl, 8);
        url.DateOfCreation = DateTime.Now;
        urlRepository.Add(url);
    }

    public void Delete(int id)
    {
        var url = GetById(id);

        if (url is null)
            throw new NullReferenceException("Url entity is null");
        
        urlRepository.Delete(url);
    }

    public void Update(Url url)
    {
        var oldUrl = GetById(url.Id);
        
        if (oldUrl is null)
            throw new NullReferenceException("Url entity is null");

        oldUrl.LongUrl = url.LongUrl;
        oldUrl.ShortenedUrl = linkShorterService.GenerateShortLink(url.LongUrl, 8);
        oldUrl.DateOfCreation = DateTime.Now;
        
        urlRepository.Update(oldUrl);
    }

    public Url? GetById(int id)
    {
        return urlRepository.GetById(id);
    }

    public async Task<IEnumerable<Url>> GetAll()
    {
        return await urlRepository.GetAll();
    }

    public async Task<Url> AddTransitionToUrl(string shortLink)
    {
        var url = (await urlRepository.GetAll())
            .First(link => link.ShortenedUrl == shortLink);

        url.TransitionCount++;
        urlRepository.Update(url);
        
        return url;
    }
}