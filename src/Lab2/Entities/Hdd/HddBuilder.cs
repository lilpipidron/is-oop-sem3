using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdd;

public class HddBuilder : IHddBuilder
{
    private string? _name;
    private int? _memoryAmount;
    private int? _spindleSpeed;
    private int? _powerConsumption;

    public IHddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHdd Build()
    {
        return new Hdd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _memoryAmount ?? throw new ArgumentNullException(nameof(_memoryAmount)),
            _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}