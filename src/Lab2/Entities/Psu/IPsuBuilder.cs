namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;

public interface IPsuBuilder
{
    IPsuBuilder WithName(string name);

    IPsuBuilder WithPeakLoad(int peakLoad);

    IPsu Build();
}