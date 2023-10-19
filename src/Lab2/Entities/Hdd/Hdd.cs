namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdd;

public class Hdd : IHdd
{
    internal Hdd(string name, int memoryAmount, int spindleSpeed, int powerConsumption)
    {
        Name = name;
        MemoryAmount = memoryAmount;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int MemoryAmount { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }

    public IHddBuilder Director(IHddBuilder builder)
    {
        builder
            .WithName(Name)
            .WithMemoryAmount(MemoryAmount)
            .WithSpindleSpeed(SpindleSpeed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}