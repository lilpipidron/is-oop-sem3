using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;

public class Bios : IBios
{
    private readonly string _biosType;
    private readonly string _version;
    private readonly IReadOnlyCollection<ICpu> _supportedCpu;

    public Bios(string biosType, string version, IEnumerable<ICpu> supportedCpu)
    {
        _biosType = biosType;
        _version = version;
        _supportedCpu = supportedCpu.ToArray();
    }
}