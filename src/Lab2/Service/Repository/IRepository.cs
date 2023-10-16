namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public interface IRepository<in T>
{
    void Add(T entity);
    void Delete(T entity);
}