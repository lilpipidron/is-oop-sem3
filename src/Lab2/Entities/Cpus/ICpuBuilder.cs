using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public interface ICpuBuilder
{
    ICpuBuilder WithCoreFrequency(int coreFrequency);

    ICpuBuilder WithCoreAmount(int coreAmount);

    ICpuBuilder WithSocket(PcSocket socket);

    ICpuBuilder WithVideoCore(IIvc? videoCore);

    ICpuBuilder WithRamFrequency(IEnumerable<int> ramFrequency);

    ICpuBuilder WithTdp(int tdp);

    ICpuBuilder WithPowerConsumption(int powerConsumption);

    ICpu Build();
}