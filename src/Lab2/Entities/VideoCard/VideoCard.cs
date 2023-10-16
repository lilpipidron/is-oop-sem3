using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public class VideoCard : IVideoCard
{
    private readonly IVideoCardDimension _dimension;
    private readonly int _memoryAmount;
    private readonly string _versionPciE;
    private readonly double _chipFrequency;
    private readonly int _powerConsumption;

    public VideoCard(
        int memoryAmount,
        string versionPciE,
        double chipFrequency,
        int powerConsumption,
        IVideoCardDimension dimension)
    {
        _memoryAmount = memoryAmount;
        _versionPciE = versionPciE;
        _chipFrequency = chipFrequency;
        _powerConsumption = powerConsumption;
        _dimension = dimension;
    }
}