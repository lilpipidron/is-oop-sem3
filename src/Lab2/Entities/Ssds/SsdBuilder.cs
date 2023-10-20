using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;

public class SsdBuilder : ISsdBuilder
{
    private int? _memoryAmount;
    private int? _maximumSpeed;
    private int? _powerConsumption;
    private string? _connectionOption;

    public ISsdBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public ISsdBuilder WithMaximumSpeed(int maximumSpeed)
    {
        _maximumSpeed = maximumSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsdBuilder WithConnectionOption(string connectionOption)
    {
        _connectionOption = connectionOption;
        return this;
    }

    public ISsd Build()
    {
        return new Ssd(
            _memoryAmount ?? throw new ArgumentNullException(nameof(_memoryAmount)),
            _maximumSpeed ?? throw new ArgumentNullException(nameof(_maximumSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _connectionOption ?? throw new ArgumentNullException(nameof(_connectionOption)));
    }
}