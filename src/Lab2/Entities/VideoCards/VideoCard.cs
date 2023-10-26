namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public class VideoCard : IVideoCard
{
    internal VideoCard(
        int height,
        int width,
        int memoryAmount,
        string versionPciE,
        double chipFrequency,
        int powerConsumption)
    {
        MemoryAmount = memoryAmount;
        VersionPciE = versionPciE;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        Height = height;
        Width = width;
    }

    public int Height { get; }
    public int Width { get; }
    public int MemoryAmount { get; }
    public string VersionPciE { get; }
    public double ChipFrequency { get; }
    public int PowerConsumption { get; }

    public IVideoCardBuilder Director(IVideoCardBuilder builder)
    {
        builder
            .WithDimension(Height, Width)
            .WithMemoryAmount(MemoryAmount)
            .WithVersionPciE(VersionPciE)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}