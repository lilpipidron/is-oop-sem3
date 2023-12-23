using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;

public interface IBios : IBuilderDirector<IBiosBuilder>, IPcComponent
{
    public string BiosType { get; }
    public string Version { get; }
    public IReadOnlyCollection<ICpu> SupportedCpu { get; }
}