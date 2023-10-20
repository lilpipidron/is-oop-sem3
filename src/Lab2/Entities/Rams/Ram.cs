using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public class Ram : IRam
{
    internal Ram(
        int amount,
        RamFormFactor ramFormFactor,
        int versionDdr,
        int powerConsumption,
        IEnumerable<SupportedFrequencyVoltagePair> supportedFrequencyVoltagePairsList,
        IEnumerable<int> availableXmpProfiles)
    {
        Amount = amount;
        RamFormFactor = ramFormFactor;
        VersionDdr = versionDdr;
        PowerConsumption = powerConsumption;
        SupportedFrequencyVoltagePairsList = supportedFrequencyVoltagePairsList.ToArray();
        AvailableXmpProfiles = availableXmpProfiles.ToArray();
    }

    public int Amount { get; }
    public RamFormFactor RamFormFactor { get; }
    public int VersionDdr { get; }
    public int PowerConsumption { get; }
    public IReadOnlyCollection<SupportedFrequencyVoltagePair> SupportedFrequencyVoltagePairsList { get; }
    public IReadOnlyCollection<int> AvailableXmpProfiles { get; }

    public IRamBuilder Director(IRamBuilder builder)
    {
        builder
            .WithAmount(Amount)
            .WithRamFormFactor(RamFormFactor)
            .WithVersionDdr(VersionDdr)
            .WithPowerConsumption(PowerConsumption)
            .WithSupportedFrequencyVoltagePairs(SupportedFrequencyVoltagePairsList)
            .WithAvailableXmpProfiles(AvailableXmpProfiles);

        return builder;
    }
}