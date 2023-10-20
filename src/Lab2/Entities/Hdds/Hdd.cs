namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public class Hdd : IHdd
{
    internal Hdd(int memoryAmount, int spindleSpeed, int powerConsumption)
    {
        MemoryAmount = memoryAmount;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int MemoryAmount { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }

    public IHddBuilder Director(IHddBuilder builder)
    {
        builder
            .WithMemoryAmount(MemoryAmount)
            .WithSpindleSpeed(SpindleSpeed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}