using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherboardAndVideoCard<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IMotherboard
    where T2 : IVideoCard?
{
    public Result CheckCompability(T1 component1, T2? component2)
    {
        return new Result.FullCompatible();
    }
}