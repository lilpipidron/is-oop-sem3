namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public interface IPsuBuilder
{
    IPsuBuilder WithName(string name);

    IPsuBuilder WithPeakLoad(int peakLoad);

    IPsu Build();
}