namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public interface IPsu : IBuilderDirector<IPsuBuilder>, IPcComponent
{
    public int PeakLoad { get; }
}