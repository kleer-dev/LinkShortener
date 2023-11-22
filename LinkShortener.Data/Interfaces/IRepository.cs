using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Interfaces;

public interface IRepository<in T>
{
    public void Add(T entity);
    public void Delete(T entity);
    public void Update(T entity);
}