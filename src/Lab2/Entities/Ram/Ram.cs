using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public class Ram : IRam
{
    private readonly int _amount;
    private readonly RamFormFactor _ramFormFactor;
    private readonly int _versionDdr;
    private readonly int _powerConsumption;
    private readonly IReadOnlyCollection<ISupportedFrequencyVoltagePairs> _supportedFrequencyVoltagePairsList;
    private readonly IReadOnlyCollection<int> _availableXmpProfiles;

    public Ram(
        int amount,
        RamFormFactor ramFormFactor,
        int versionDdr,
        int powerConsumption,
        IEnumerable<ISupportedFrequencyVoltagePairs> supportedFrequencyVoltagePairsList,
        IEnumerable<int> availableXmpProfiles)
    {
        _amount = amount;
        _ramFormFactor = ramFormFactor;
        _versionDdr = versionDdr;
        _powerConsumption = powerConsumption;
        _supportedFrequencyVoltagePairsList = supportedFrequencyVoltagePairsList.ToArray();
        _availableXmpProfiles = availableXmpProfiles.ToArray();
    }
}