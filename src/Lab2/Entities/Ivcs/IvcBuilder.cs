using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;

public class IvcBuilder : IIvcBuilder
{
    private int? _tdp;
    private int? _memoryAmount;
    private int? _clockFrequency;

    public IIvcBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IIvcBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public IIvcBuilder WithClockFrequency(int clockFrequency)
    {
        _clockFrequency = clockFrequency;
        return this;
    }

    public IIvc Build()
    {
        return new Ivc(
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _memoryAmount ?? throw new ArgumentNullException(nameof(_memoryAmount)),
            _clockFrequency ?? throw new ArgumentNullException(nameof(_clockFrequency)));
    }
}