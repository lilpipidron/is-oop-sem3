using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;

internal class Bios : IBios
{
    public Bios(string name, string biosType, string version, IEnumerable<ICpu> supportedCpu)
    {
        Name = name;
        BiosType = biosType;
        Version = version;
        SupportedCpu = supportedCpu.ToArray();
    }

    public string Name { get; }
    public string BiosType { get; }
    public string Version { get; }
    public IReadOnlyCollection<ICpu> SupportedCpu { get; }

    public IBiosBuilder Director(IBiosBuilder builder)
    {
        builder
            .WithName(Name)
            .WithBiosType(BiosType)
            .WithVersion(Version)
            .WithSupportedCpu(SupportedCpu);

        return builder;
    }
}