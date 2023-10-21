using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public interface IRam : IBuilderDirector<IRamBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption
{
    public int Amount { get; }
    public RamFormFactor RamFormFactor { get; }
    public int VersionDdr { get; }
    public Jedec JedecProfile { get; }
    public Xmp? XmpProfile { get; }
}