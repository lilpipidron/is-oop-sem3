using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public interface ICpuBuilder
{
    ICpuBuilder WithName(string name);

    ICpuBuilder WithCoreFrequency(double coreFrequency);

    ICpuBuilder WithCoreAmount(double coreAmount);

    ICpuBuilder WithSocket(string socket);

    ICpuBuilder WithVideoCore(bool videoCore);

    ICpuBuilder WithRamFrequency(IEnumerable<int> ramFrequency);

    ICpuBuilder WithTdp(int tdp);

    ICpuBuilder WithPowerConsumption(int powerConsumption);

    ICpu Build();
}