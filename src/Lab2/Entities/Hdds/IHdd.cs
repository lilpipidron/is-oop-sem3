namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public interface IHdd : IBuilderDirector<IHddBuilder>, IHasName
{
    public int MemoryAmount { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }
}