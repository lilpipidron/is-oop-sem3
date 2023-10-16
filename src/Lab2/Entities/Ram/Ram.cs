using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public class Ram : IRam
{
    private readonly int _amount;
    private readonly RamFormFactor _ramFormFactor;
    private readonly int _versionDdr;
    private readonly int _powerConsumption;
    private readonly Collection<ISupportedFrequencyVoltagePairs> _supportedFrequencyVoltagePairsList;
    private readonly Collection<int> _availableXmpProfiles;

    public Ram(
        int amount,
        RamFormFactor ramFormFactor,
        int versionDdr,
        int powerConsumption,
        Collection<ISupportedFrequencyVoltagePairs> supportedFrequencyVoltagePairsList,
        Collection<int> availableXmpProfiles)
    {
        _amount = amount;
        _ramFormFactor = ramFormFactor;
        _versionDdr = versionDdr;
        _powerConsumption = powerConsumption;
        _supportedFrequencyVoltagePairsList = supportedFrequencyVoltagePairsList;
        _availableXmpProfiles = availableXmpProfiles;
    }
}