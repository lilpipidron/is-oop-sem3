using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndCoolingSystem : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var coolingSystem = pcComponents.FirstOrDefault(component => component is ICoolingSystem) as ICoolingSystem;
        var cpu = pcComponents.FirstOrDefault(component => component is ICpu) as ICpu;

        if (cpu is null)
        {
            throw new ArgumentNullException(null, nameof(cpu));
        }

        if (coolingSystem?.Socket.FirstOrDefault(socket => cpu.Socket.Equals(socket)) is null)
        {
            return new ComponentResult.Failed("The cooling system does not support the CPU socket");
        }

        if (cpu.Tdp > coolingSystem.MaxTdp)
        {
            return new ComponentResult.Compatible("The store disclaims liability and warranty obligations");
        }

        return new ComponentResult.FullCompatible();
    }
}