namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssd;

public class Ssd : ISsd
{
    private readonly int _memoryAmount;
    private readonly int _maximumSpeed;
    private readonly int _powerConsumption;
    private readonly string _connectionOption;

    public Ssd(int memoryAmount, int maximumSpeed, int powerConsumption, string connectionOption)
    {
        _memoryAmount = memoryAmount;
        _maximumSpeed = maximumSpeed;
        _powerConsumption = powerConsumption;
        _connectionOption = connectionOption;
    }
}