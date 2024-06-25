using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class PcComponentRepository : IRepository<IPcComponent>
{
    private readonly List<IPcComponent> _entity;

    public PcComponentRepository()
    {
        _entity = new List<IPcComponent>();
    }

    public IReadOnlyCollection<IPcComponent> GetAllComponents()
    {
        return _entity;
    }

    public void Add(IPcComponent entity)
    {
        _entity.Add(entity);
    }

    public void Delete(IPcComponent entity)
    {
        _entity.Remove(entity);
    }
}