namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssd;

public interface ISsdBuilder
{
    ISsdBuilder WithMemoryAmount(int memoryAmount);
    ISsdBuilder WithMaximumSpeed(int maximumSpeed);
    ISsdBuilder WithPowerConsumption(int powerConsumption);
    ISsdBuilder WithConnectionOption(string connectionOption);
}