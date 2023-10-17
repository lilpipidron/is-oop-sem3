namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdd;

public class Hdd : IHdd
{
    private readonly int _memoryAmount;
    private readonly int _spindleSpeed;
    private readonly int _powerConsumption;

    public Hdd(int memoryAmount, int spindleSpeed, int powerConsumption)
    {
        _memoryAmount = memoryAmount;
        _spindleSpeed = spindleSpeed;
        _powerConsumption = powerConsumption;
    }

    public IHddBuilder Director(IHddBuilder builder)
    {
        builder
            .WithMemoryAmount(_memoryAmount)
            .WithSpindleSpeed(_spindleSpeed)
            .WithPowerConsumption(_powerConsumption);

        return builder;
    }
}