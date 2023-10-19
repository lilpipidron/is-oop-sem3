using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithName(string name);

    IVideoCardBuilder WithDimension(Dimension.VideoCardDimension dimension);

    IVideoCardBuilder WithMemoryAmount(int memoryAmount);

    IVideoCardBuilder WithVersionPciE(string versionPciE);

    IVideoCardBuilder WithChipFrequency(double chipFrequency);

    IVideoCardBuilder WithPowerConsumption(int powerConsumption);

    IVideoCard Build();
}