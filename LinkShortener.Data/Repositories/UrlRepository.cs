using LinkShortener.Data.Entities;
using LinkShortener.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Repositories;

public class UrlRepository(ApplicationContext dbContext) : IRepository<Url>
{
    public void Add(Url entity)
    {
        dbContext.Add(entity);
        dbContext.SaveChanges();
    }

    public void Delete(Url entity)
    {
        dbContext.Remove(entity);
        dbContext.SaveChanges();
    }

    public void Update(Url entity)
    {
        dbContext.Update(entity);
        dbContext.SaveChanges();
    }

    public async Task<IEnumerable<Url>> GetAll() => await dbContext.Urls.ToListAsync();

    public Url? GetById(int id) =>
        dbContext.Urls.FirstOrDefault(url => url.Id == id);
}