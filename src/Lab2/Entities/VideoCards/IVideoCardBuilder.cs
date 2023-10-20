using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithDimension(Dimension.HWDimension dimension);

    IVideoCardBuilder WithMemoryAmount(int memoryAmount);

    IVideoCardBuilder WithVersionPciE(string versionPciE);

    IVideoCardBuilder WithChipFrequency(double chipFrequency);

    IVideoCardBuilder WithPowerConsumption(int powerConsumption);

    IVideoCard Build();
}