using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherboardAndCpu : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var cpu = pcComponents.FirstOrDefault(component => component is ICpu) as ICpu;
        var motherboard = pcComponents.FirstOrDefault(component => component is IMotherboard) as IMotherboard;
        if (motherboard?.Socket.Equals(cpu?.Socket) is false)
        {
            return new ComponentResult.Failed("Sockets don't match");
        }

        if (cpu is null)
        {
            throw new ArgumentNullException(null, nameof(cpu));
        }

        if (motherboard?.Bios.SupportedCpu.FirstOrDefault(component => cpu.Equals(component)) is null)
        {
            return new ComponentResult.Failed("BIOS does not support this cpu");
        }

        return new ComponentResult.FullCompatible();
    }
}