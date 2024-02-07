namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;

public interface IIvc : IBuilderDirector<IIvcBuilder>
{
    int Tdp { get; }
    int MemoryAmount { get; }
    int ClockFrequency { get; }
}