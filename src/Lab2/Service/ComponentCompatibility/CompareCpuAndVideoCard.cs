using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndVideoCard<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : ICpu
    where T2 : IVideoCard?
{
    public Result CheckCompability(T1 component1, T2? component2)
    {
        if (component2 is not null) return new Result.FullCompatible();
        if (component1.VideoCore is null)
        {
            return new Result.Failed("System has no GPU");
        }

        return new Result.FullCompatible();
    }
}