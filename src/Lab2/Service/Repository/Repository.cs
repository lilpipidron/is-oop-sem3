using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class Repository<T> : IRepository<T>
    where T : IPcComponent
{
    private Collection<T> _entity = new();

    public IEnumerable<T> GetAllComponents()
    {
        return _entity;
    }

    public void Add(T entity)
    {
        _entity.Add(entity);
    }

    public void Delete(T entity)
    {
        _entity.Remove(entity);
    }
}