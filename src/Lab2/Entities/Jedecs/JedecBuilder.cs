using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;

public class JedecBuilder : IJedecBuilder
{
    private string? _timings;
    private int? _voltage;
    private int? _frequency;

    public IJedecBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public IJedecBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IJedecBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IJedec Build()
    {
        return new Jedecs.Jedec(
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage ?? throw new ArgumentNullException(nameof(_voltage)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)));
    }
}