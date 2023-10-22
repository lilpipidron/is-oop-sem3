using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public interface ICpu : IBuilderDirector<ICpuBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption
{
    public int CoreFrequency { get; }
    public int CoreAmount { get; }
    public PcSocket Socket { get; }
    public bool VideoCore { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
    public int Tdp { get; }
}