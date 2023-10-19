using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class Repository<T> : IRepository<T>
    where T : class, IHasName
{
    public Repository(Collection<T> entity)
    {
        Entity = entity;
    }

    public Collection<T> Entity { get; }

    public T? Find(string name)
    {
        return Entity.FirstOrDefault(e => e.Name == name);
    }

    public void Add(T entity)
    {
        Entity.Add(entity);
    }

    public void Delete(T entity)
    {
        Entity.Remove(entity);
    }
}