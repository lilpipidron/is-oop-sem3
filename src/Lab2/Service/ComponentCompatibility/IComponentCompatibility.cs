using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public interface IComponentCompatibility<T1, T2>
{
    public Result CheckCompability(T1 component1, T2 component2);
}