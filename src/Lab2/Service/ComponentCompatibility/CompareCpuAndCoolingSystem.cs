using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndCoolingSystem : IComponentCompatibility
{
    private readonly ICpu _cpu;
    private readonly ICoolingSystem _coolingSystem;

    public CompareCpuAndCoolingSystem(ICpu cpu, ICoolingSystem coolingSystem)
    {
        _cpu = cpu;
        _coolingSystem = coolingSystem;
    }

    public ComponentResult CheckCompability()
    {
        if (_coolingSystem.Socket.FirstOrDefault(socket => _cpu.Socket.Equals(socket)) is null)
        {
            return new ComponentResult.Failed("The cooling system does not support the CPU socket");
        }

        if (_cpu.Tdp > _coolingSystem.MaxTdp)
        {
            return new ComponentResult.Compatible("The store disclaims liability and warranty obligations");
        }

        return new ComponentResult.FullCompatible();
    }
}