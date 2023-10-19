namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public interface IHddBuilder
{
    IHddBuilder WithName(string name);

    IHddBuilder WithMemoryAmount(int memoryAmount);

    IHddBuilder WithSpindleSpeed(int spindleSpeed);

    IHddBuilder WithPowerConsumption(int powerConsumption);

    IHdd Build();
}