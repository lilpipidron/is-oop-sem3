using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    private Collection<T?> _entity = new();

    public Repository()
    {
        _entity.Add(new Psu(123) as T);
    }

    public IEnumerable<T?> GetAllComponents()
    {
        return _entity;
    }

    public void Add(T? entity)
    {
        _entity.Add(entity);
    }

    public void Delete(T? entity)
    {
        _entity.Remove(entity);
    }
}