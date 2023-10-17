namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;

public interface IPsuBuilder
{
    IPsuBuilder WithPeakLoad(int peakLoad);

    IPsu Build();
}