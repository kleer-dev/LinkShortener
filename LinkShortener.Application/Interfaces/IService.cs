namespace LinkShortener.Application.Interfaces;

public interface IService<T>
{
    public void Add(T url);
    public void Delete(int id);
    public void Update(T url);
    public T? GetById(int id);
    public Task<IEnumerable<T>> GetAll();
}