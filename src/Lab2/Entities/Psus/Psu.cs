namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public class Psu : IPsu
{
    internal Psu(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }

    public IPsuBuilder Director(IPsuBuilder builder)
    {
        builder
            .WithPeakLoad(PeakLoad);

        return builder;
    }
}