using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public interface IRam : IBuilderDirector<IRamBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption
{
    public int Amount { get; }
    public RamFormFactor RamFormFactor { get; }
    public int VersionDdr { get; }
    public IReadOnlyCollection<SupportedFrequencyVoltagePair> SupportedFrequencyVoltagePairsList { get; }
    public IReadOnlyCollection<int> AvailableXmpProfiles { get; }
}