using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    public Repository(Collection<T> entity)
    {
        Entity = entity;
    }

    public Collection<T> Entity { get; }

    public void Add(T entity)
    {
        Entity.Add(entity);
    }

    public void Delete(T entity)
    {
        Entity.Remove(entity);
    }
}