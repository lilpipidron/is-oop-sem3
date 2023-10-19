using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

public class XmpBuilder : IXmpBuilder
{
    private string? _name;
    private string? _timings;
    private int? _voltage;
    private int? _frequency;

    public IXmpBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IXmpBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IXmp Build()
    {
        return new Xmp(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage ?? throw new ArgumentNullException(nameof(_voltage)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)));
    }
}