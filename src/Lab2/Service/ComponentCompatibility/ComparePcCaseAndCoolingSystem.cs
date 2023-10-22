using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndCoolingSystem<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IPcCase
    where T2 : ICoolingSystem
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        if (component1.Dimension.IsCompatible(component2.Dimension) is false)
        {
            return new Result.Failed("Cooling System does not fit into the case");
        }

        return new Result.FullCompatible();
    }
}