using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;

public interface IBiosBuilder
{
    IBiosBuilder WithBiosType(string biosType);

    IBiosBuilder WithVersion(string version);

    IBiosBuilder WithSupportedCpu(IEnumerable<ICpu> supportedCpu);
}