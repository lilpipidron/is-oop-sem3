using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public interface IRepository<T>
    where T : IPcComponent
{
    public IReadOnlyCollection<T> GetAllComponents();
    void Add(T entity);
    void Delete(T entity);
}