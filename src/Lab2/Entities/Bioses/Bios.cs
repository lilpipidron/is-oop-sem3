using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;

public class Bios : IBios
{
    internal Bios(string biosType, string version, IEnumerable<ICpu> supportedCpu)
    {
        BiosType = biosType;
        Version = version;
        SupportedCpu = supportedCpu.ToArray();
    }

    public string BiosType { get; }
    public string Version { get; }
    public IReadOnlyCollection<ICpu> SupportedCpu { get; }

    public IBiosBuilder Director(IBiosBuilder builder)
    {
        builder
            .WithBiosType(BiosType)
            .WithVersion(Version)
            .WithSupportedCpu(SupportedCpu);

        return builder;
    }
}