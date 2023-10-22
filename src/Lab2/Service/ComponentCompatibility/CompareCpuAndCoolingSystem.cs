using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndCoolingSystem<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : ICpu
    where T2 : ICoolingSystem
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        if (component2.Socket.FirstOrDefault(socket => component1.Socket.Equals(socket)) is null)
        {
            return new Result.Failed("The cooling system does not support the CPU socket");
        }

        if (component1.Tdp > component2.MaxTdp)
        {
            return new Result.Compatible("The store disclaims liability and warranty obligations");
        }

        return new Result.FullCompatible();
    }
}