using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public interface IRamBuilder
{
    IRamBuilder WithName(string name);

    IRamBuilder WithAmount(int amount);

    IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor);

    IRamBuilder WithVersionDdr(int versionDdr);

    IRamBuilder WithPowerConsumption(int powerConsumption);

    IRamBuilder WithSupportedFrequencyVoltagePairs(
        IEnumerable<SupportedFrequencyVoltagePair> supportedFrequencyVoltagePairsList);

    IRamBuilder WithAvailableXmpProfiles(IEnumerable<int> availableXmpProfiles);

    IRam Build();
}