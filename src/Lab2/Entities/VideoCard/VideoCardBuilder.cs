using System;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private string? _name;
    private Dimension.VideoCardDimension? _dimension;
    private int? _memoryAmount;
    private string? _versionPciE;
    private double? _chipFrequency;
    private int? _powerConsumption;

    public IVideoCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IVideoCardBuilder WithDimension(Dimension.VideoCardDimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public IVideoCardBuilder WithMemoryAmount(int memoryAmount)
    {
        _memoryAmount = memoryAmount;
        return this;
    }

    public IVideoCardBuilder WithVersionPciE(string versionPciE)
    {
        _versionPciE = versionPciE;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(double chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IVideoCard Build()
    {
        return new VideoCard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)),
            _memoryAmount ?? throw new ArgumentNullException(nameof(_memoryAmount)),
            _versionPciE ?? throw new ArgumentNullException(nameof(_versionPciE)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}