using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherboardAndCpu<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IMotherboard
    where T2 : ICpu
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        if (component1.Socket.Equals(component2.Socket) is false)
        {
            return new Result.Failed("Sockets don't match");
        }

        if (component1.Bios.SupportedCpu.FirstOrDefault(cpu => component2.Equals(cpu)) is null)
        {
            return new Result.Failed("BIOS does not support this cpu");
        }

        return new Result.FullCompatible();
    }
}