using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public class CpuBuilder : ICpuBuilder
{
    private string? _name;
    private double? _coreFrequency;
    private double? _coreAmount;
    private string? _socket;
    private bool _videoCore;
    private IReadOnlyCollection<int>? _ramFrequency;
    private int? _tdp;
    private int? _powerConsumption;

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreAmount(double coreAmount)
    {
        _coreAmount = coreAmount;
        return this;
    }

    public ICpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithVideoCore(bool videoCore)
    {
        _videoCore = videoCore;
        return this;
    }

    public ICpuBuilder WithRamFrequency(IEnumerable<int> ramFrequency)
    {
        _ramFrequency = ramFrequency.ToArray();
        return this;
    }

    public ICpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpu Build()
    {
        return new Cpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _coreAmount ?? throw new ArgumentNullException(nameof(_coreAmount)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _videoCore,
            _ramFrequency ?? throw new ArgumentNullException(nameof(_ramFrequency)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}