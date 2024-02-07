namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public interface IPsuBuilder
{
    IPsuBuilder WithPeakLoad(int peakLoad);

    IPsu Build();
}