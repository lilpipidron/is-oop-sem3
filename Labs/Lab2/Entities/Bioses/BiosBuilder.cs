using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;

public class BiosBuilder : IBiosBuilder
{
    private string? _biosType;
    private string? _version;
    private IReadOnlyCollection<ICpu>? _supportedCpu;

    public IBiosBuilder WithBiosType(string biosType)
    {
        _biosType = biosType;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportedCpu(IEnumerable<ICpu> supportedCpu)
    {
        _supportedCpu = supportedCpu.ToArray();
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            _biosType ?? throw new ArgumentNullException(nameof(_biosType)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _supportedCpu ?? throw new ArgumentNullException(nameof(_supportedCpu)));
    }
}