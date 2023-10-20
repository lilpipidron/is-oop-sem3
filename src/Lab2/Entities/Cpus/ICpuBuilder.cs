using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public interface ICpuBuilder
{
    ICpuBuilder WithCoreFrequency(double coreFrequency);

    ICpuBuilder WithCoreAmount(double coreAmount);

    ICpuBuilder WithSocket(PcSocket socket);

    ICpuBuilder WithVideoCore(bool videoCore);

    ICpuBuilder WithRamFrequency(IEnumerable<int> ramFrequency);

    ICpuBuilder WithTdp(int tdp);

    ICpuBuilder WithPowerConsumption(int powerConsumption);

    ICpu Build();
}