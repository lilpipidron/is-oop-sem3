namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithDimension(int height, int width);

    IVideoCardBuilder WithMemoryAmount(int memoryAmount);

    IVideoCardBuilder WithVersionPciE(string versionPciE);

    IVideoCardBuilder WithChipFrequency(double chipFrequency);

    IVideoCardBuilder WithPowerConsumption(int powerConsumption);

    IVideoCard Build();
}