namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;

public interface IIvc : IBuilderDirector<IIvcBuilder>
{
public int Tdp { get; }
public int MemoryAmount { get; }
public int ClockFrequency { get; }
}