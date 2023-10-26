using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherboardAndCpu : IComponentCompatibility
{
    private readonly IMotherboard _motherboard;
    private readonly ICpu _cpu;

    public CompareMotherboardAndCpu(IMotherboard motherboard, ICpu cpu)
    {
        _motherboard = motherboard;
        _cpu = cpu;
    }

    public ComponentResult CheckCompability()
    {
        if (_motherboard.Socket.Equals(_cpu.Socket) is false)
        {
            return new ComponentResult.Failed("Sockets don't match");
        }

        if (_motherboard.Bios.SupportedCpu.FirstOrDefault(component => _cpu.Equals(component)) is null)
        {
            return new ComponentResult.Failed("BIOS does not support this cpu");
        }

        return new ComponentResult.FullCompatible();
    }
}