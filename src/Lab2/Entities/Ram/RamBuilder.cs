using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public class RamBuilder : IRamBuilder
{
    private int? _amount;
    private RamFormFactor? _ramFormFactor;
    private int? _versionDdr;
    private int? _powerConsumption;
    private IReadOnlyCollection<SupportedFrequencyVoltagePairs>? _supportedFrequencyVoltagePairsList;
    private IReadOnlyCollection<int>? _availableXmpProfiles;

    public IRamBuilder WithAmount(int amount)
    {
        _amount = amount;
        return this;
    }

    public IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IRamBuilder WithVersionDdr(int versionDdr)
    {
        _versionDdr = versionDdr;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRamBuilder WithSupportedFrequencyVoltagePairs(
        IEnumerable<SupportedFrequencyVoltagePairs> supportedFrequencyVoltagePairsList)
    {
        _supportedFrequencyVoltagePairsList = supportedFrequencyVoltagePairsList.ToArray();
        return this;
    }

    public IRamBuilder WithAvailableXmpProfiles(IEnumerable<int> availableXmpProfiles)
    {
        _availableXmpProfiles = availableXmpProfiles.ToArray();
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            _amount ?? throw new ArgumentNullException(nameof(_amount)),
            _ramFormFactor ?? throw new ArgumentNullException(nameof(_ramFormFactor)),
            _versionDdr ?? throw new ArgumentNullException(nameof(_versionDdr)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _supportedFrequencyVoltagePairsList ?? throw new ArgumentNullException(nameof(_supportedFrequencyVoltagePairsList)),
            _availableXmpProfiles ?? throw new ArgumentNullException(nameof(_availableXmpProfiles)));
    }
}