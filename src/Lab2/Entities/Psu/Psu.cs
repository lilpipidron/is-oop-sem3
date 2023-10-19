namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;

public class Psu : IPsu
{
    internal Psu(string name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public string Name { get; }
    public int PeakLoad { get; }

    public IPsuBuilder Director(IPsuBuilder builder)
    {
        builder
            .WithName(Name)
            .WithPeakLoad(PeakLoad);

        return builder;
    }
}