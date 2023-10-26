using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndRam : IComponentCompatibility
{
    private readonly ICpu _cpu;
    private readonly IReadOnlyCollection<IRam> _ram;

    public CompareCpuAndRam(ICpu cpu, IReadOnlyCollection<IRam> ram)
    {
        _cpu = cpu;
        _ram = ram;
    }

    public ComponentResult CheckCompability()
    {
        foreach (IRam ram in _ram)
        {
            if (ram.XmpProfile is not null)
            {
                if (ram.XmpProfile.Frequency != _cpu.CoreFrequency)
                {
                    return new ComponentResult.Failed("The processor does not support these frequencies");
                }
            }

            if (ram.JedecProfile.Frequency == _cpu.CoreFrequency)
            {
                return new ComponentResult.Failed("The processor does not support these frequencies");
            }
        }

        return new ComponentResult.FullCompatible();
    }
}