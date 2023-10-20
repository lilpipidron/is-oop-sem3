using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public class Cpu : ICpu
{
    internal Cpu(
        double coreFrequency,
        double coreAmount,
        string socket,
        bool videoCore,
        IEnumerable<int> ramFrequency,
        int tdp,
        int powerConsumption)
    {
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        Socket = socket;
        VideoCore = videoCore;
        RamFrequency = ramFrequency.ToArray();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public double CoreFrequency { get; }
    public double CoreAmount { get; }
    public string Socket { get; }
    public bool VideoCore { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public ICpuBuilder Director(ICpuBuilder builder)
    {
        builder
            .WithCoreFrequency(CoreFrequency)
            .WithCoreAmount(CoreAmount)
            .WithSocket(Socket)
            .WithVideoCore(VideoCore)
            .WithRamFrequency(RamFrequency)
            .WithTdp(Tdp)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}