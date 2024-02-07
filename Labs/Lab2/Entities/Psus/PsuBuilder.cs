using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public class PsuBuilder : IPsuBuilder
{
    private int? _peakLoad;

    public IPsuBuilder WithPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPsu Build()
    {
        return new Psu(
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }
}