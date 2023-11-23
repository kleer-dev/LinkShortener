using LinkShortener.Data.Entities;

namespace LinkShortener.Application.Interfaces;

public interface IUrlService : IService<Url>
{
    public Task<Url> AddTransitionToUrl(string shortLink);
}