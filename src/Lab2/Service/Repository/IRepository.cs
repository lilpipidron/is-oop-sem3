using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public interface IRepository<T>
{
    public IReadOnlyCollection<T?> GetAllComponents();
    void Add(T? entity);
    void Delete(T? entity);
}