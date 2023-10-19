namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public interface IHdd : IHddBuilderDirector, IHasName
{
    public int MemoryAmount { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }
}