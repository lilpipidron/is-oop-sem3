namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssd;

public class Ssd : ISsd
{
    internal Ssd(string name, int memoryAmount, int maximumSpeed, int powerConsumption, string connectionOption)
    {
        Name = name;
        MemoryAmount = memoryAmount;
        MaximumSpeed = maximumSpeed;
        PowerConsumption = powerConsumption;
        ConnectionOption = connectionOption;
    }

    public string Name { get; }
    public int MemoryAmount { get; }
    public int MaximumSpeed { get; }
    public int PowerConsumption { get; }
    public string ConnectionOption { get; }

    public ISsdBuilder Director(ISsdBuilder builder)
    {
        builder
            .WithName(Name)
            .WithMemoryAmount(MemoryAmount)
            .WithMaximumSpeed(MaximumSpeed)
            .WithPowerConsumption(PowerConsumption)
            .WithConnectionOption(ConnectionOption);

        return builder;
    }
}