using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;

public class Bios : IBios
{
    private readonly string _bios;
    private readonly string _version;
    private readonly Collection<ICpu> _supportedCpu;

    public Bios(string bios, string version, Collection<ICpu> supportedCpu)
    {
        _bios = bios;
        _version = version;
        _supportedCpu = supportedCpu;
    }
}