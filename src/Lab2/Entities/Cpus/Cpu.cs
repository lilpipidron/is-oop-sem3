using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public class Cpu : ICpu
{
    internal Cpu(
        int coreFrequency,
        int coreAmount,
        PcSocket pcSocket,
        bool videoCore,
        IEnumerable<int> ramFrequency,
        int tdp,
        int powerConsumption)
    {
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        Socket = pcSocket;
        VideoCore = videoCore;
        RamFrequency = ramFrequency.ToArray();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public int CoreFrequency { get; }
    public int CoreAmount { get; }
    public PcSocket Socket { get; }
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

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Equals((Cpu)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CoreFrequency, CoreAmount, Socket, VideoCore, RamFrequency, Tdp, PowerConsumption);
    }

    private bool Equals(ICpu? other)
    {
        if (other == null)
        {
            return false;
        }

        return CoreFrequency == other.CoreFrequency
               && CoreAmount == other.CoreAmount
               && Socket == other.Socket
               && VideoCore == other.VideoCore
               && RamFrequency.SequenceEqual(other.RamFrequency)
               && Tdp == other.Tdp
               && PowerConsumption == other.PowerConsumption;
    }
}