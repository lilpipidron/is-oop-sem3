namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssd;

public class Ssd : ISsd
{
    // пока хз, потом разберусь с подключением
    private readonly int _memoryAmount;
    private readonly int _maximumSpeed;
    private readonly int _powerConsumption;

    public Ssd(int memoryAmount, int maximumSpeed, int powerConsumption)
    {
        _memoryAmount = memoryAmount;
        _maximumSpeed = maximumSpeed;
        _powerConsumption = powerConsumption;
    }
}