using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndRam<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : ICpu
    where T2 : Collection<IRam>
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        foreach (IRam ram in component2)
        {
            if (ram.XmpProfile is not null)
            {
                if (ram.XmpProfile.Frequency != component1.CoreFrequency)
                {
                    return new Result.Failed("The processor does not support these frequencies");
                }
            }

            if (ram.JedecProfile.Frequency == component1.CoreFrequency)
            {
                return new Result.Failed("The processor does not support these frequencies");
            }
        }

        return new Result.FullCompatible();
    }
}