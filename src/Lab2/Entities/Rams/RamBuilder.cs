using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public class RamBuilder : IRamBuilder
{
    private int? _amount;
    private RamFormFactor? _ramFormFactor;
    private int? _versionDdr;
    private int? _powerConsumption;
    private Jedec? _jedecProfile;
    private Xmp? _xmpProfile;
    private int? _amountBoards;

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

    public IRamBuilder WithJedec(Jedec jedecProfile)
    {
        _jedecProfile = jedecProfile;
        return this;
    }

    public IRamBuilder WithXmpProfiles(Xmp? xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public IRamBuilder WithAmountBoards(int amount)
    {
        _amountBoards = amount;
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            _amount ?? throw new ArgumentNullException(nameof(_amount)),
            _ramFormFactor ?? throw new ArgumentNullException(nameof(_ramFormFactor)),
            _versionDdr ?? throw new ArgumentNullException(nameof(_versionDdr)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _jedecProfile ?? throw new ArgumentNullException(nameof(_jedecProfile)),
            _xmpProfile,
            _amountBoards ?? throw new ArgumentNullException(nameof(_amountBoards)));
    }
}