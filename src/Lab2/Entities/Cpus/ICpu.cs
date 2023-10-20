using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public interface ICpu : IBuilderDirector<ICpuBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption
{
    public double CoreFrequency { get; }
    public double CoreAmount { get; }
    public PcSocket Socket { get; }
    public bool VideoCore { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
    public int Tdp { get; }
}