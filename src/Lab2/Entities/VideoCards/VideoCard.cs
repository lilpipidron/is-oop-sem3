using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public class VideoCard : IVideoCard
{
    internal VideoCard(
        string name,
        Dimension.VideoCardDimension dimension,
        int memoryAmount,
        string versionPciE,
        double chipFrequency,
        int powerConsumption)
    {
        Name = name;
        Dimension = dimension;
        MemoryAmount = memoryAmount;
        VersionPciE = versionPciE;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public Dimension.VideoCardDimension Dimension { get; }
    public int MemoryAmount { get; }
    public string VersionPciE { get; }
    public double ChipFrequency { get; }
    public int PowerConsumption { get; }

    public IVideoCardBuilder Director(IVideoCardBuilder builder)
    {
        builder
            .WithName(Name)
            .WithDimension(Dimension)
            .WithMemoryAmount(MemoryAmount)
            .WithVersionPciE(VersionPciE)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}