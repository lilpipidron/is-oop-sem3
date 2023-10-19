using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;

public class PsuBuilder : IPsuBuilder
{
    private string? _name;
    private int? _peakLoad;

    public IPsuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPsuBuilder WithPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPsu Build()
    {
        return new Psu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }
}