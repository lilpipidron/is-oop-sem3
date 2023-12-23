using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public interface IRamBuilder
{
    IRamBuilder WithAmount(int amount);

    IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor);

    IRamBuilder WithVersionDdr(int versionDdr);

    IRamBuilder WithPowerConsumption(int powerConsumption);

    IRamBuilder WithJedec(Jedec jedecProfile);

    IRamBuilder WithXmpProfiles(Xmp? xmpProfile);

    IRamBuilder WithAmountBoards(int amount);

    IRam Build();
}