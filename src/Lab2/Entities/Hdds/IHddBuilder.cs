namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public interface IHddBuilder
{
    IHddBuilder WithMemoryAmount(int memoryAmount);

    IHddBuilder WithSpindleSpeed(int spindleSpeed);

    IHddBuilder WithPowerConsumption(int powerConsumption);

    IHdd Build();
}