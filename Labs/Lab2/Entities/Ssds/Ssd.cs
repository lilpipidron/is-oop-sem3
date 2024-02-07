namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;

public class Ssd : ISsd
{
    internal Ssd(int memoryAmount, int maximumSpeed, int powerConsumption, string connectionOption)
    {
        MemoryAmount = memoryAmount;
        MaximumSpeed = maximumSpeed;
        PowerConsumption = powerConsumption;
        ConnectionOption = connectionOption;
    }

    public int MemoryAmount { get; }
    public int MaximumSpeed { get; }
    public int PowerConsumption { get; }
    public string ConnectionOption { get; }

    public ISsdBuilder Director(ISsdBuilder builder)
    {
        builder
            .WithMemoryAmount(MemoryAmount)
            .WithMaximumSpeed(MaximumSpeed)
            .WithPowerConsumption(PowerConsumption)
            .WithConnectionOption(ConnectionOption);

        return builder;
    }
}