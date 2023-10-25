using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public class CpuBuilder : ICpuBuilder
{
    private int? _coreFrequency;
    private int? _coreAmount;
    private PcSocket? _socket;
    private IIvc? _videoCore;
    private IReadOnlyCollection<int>? _ramFrequency;
    private int? _tdp;
    private int? _powerConsumption;

    public ICpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreAmount(int coreAmount)
    {
        _coreAmount = coreAmount;
        return this;
    }

    public ICpuBuilder WithSocket(PcSocket socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithVideoCore(IIvc? videoCore)
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
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _coreAmount ?? throw new ArgumentNullException(nameof(_coreAmount)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _videoCore,
            _ramFrequency ?? throw new ArgumentNullException(nameof(_ramFrequency)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}