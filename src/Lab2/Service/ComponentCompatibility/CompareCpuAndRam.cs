using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndRam : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var ram = pcComponents.FirstOrDefault(component => component is IRam) as IRam;
        var cpu = pcComponents.FirstOrDefault(component => component is ICpu) as ICpu;

        if (ram?.XmpProfile is not null)
        {
            if (ram.XmpProfile.Frequency != cpu?.CoreFrequency)
            {
                return new ComponentResult.Failed("The processor does not support these frequencies");
            }
        }

        if (ram?.JedecProfile.Frequency == cpu?.CoreFrequency)
        {
            return new ComponentResult.Failed("The processor does not support these frequencies");
        }

        return new ComponentResult.FullCompatible();
    }
}