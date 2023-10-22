using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndVideoCard<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IPcCase
    where T2 : IVideoCard?
{
    public Result CheckCompability(T1 component1, T2? component2)
    {
        if (component2 is null)
        {
            return new Result.FullCompatible();
        }

        if (component1.MaxDimension.IsCompatible(component2.Dimension) is false)
        {
            return new Result.Failed("The video card does not fit into the case");
        }

        return new Result.FullCompatible();
    }
}