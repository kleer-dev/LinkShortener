﻿using LinkShortener.Data.Entities;

namespace LinkShortener.Data.Interfaces;

public interface IRepository<T>
{
    public void Add(T entity);
    public void Delete(T entity);
    public void Update(T entity);
    public Task<IEnumerable<Url>> GetAll();
    public T? GetById(int id);
}