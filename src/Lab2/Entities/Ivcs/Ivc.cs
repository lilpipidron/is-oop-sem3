using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;

public class Ivc : IIvc
{
    internal Ivc(int tdp, int memoryAmount, int clockFrequency)
    {
        Tdp = tdp;
        MemoryAmount = memoryAmount;
        ClockFrequency = clockFrequency;
    }

    public int Tdp { get; }
    public int MemoryAmount { get; }
    public int ClockFrequency { get; }

    public IIvcBuilder Director(IIvcBuilder builder)
    {
        builder
            .WithTdp(Tdp)
            .WithMemoryAmount(MemoryAmount)
            .WithClockFrequency(ClockFrequency);
        return builder;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Ivc)obj;
        return Tdp == other.Tdp && MemoryAmount == other.MemoryAmount && ClockFrequency == other.ClockFrequency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Tdp, MemoryAmount, ClockFrequency);
    }
}