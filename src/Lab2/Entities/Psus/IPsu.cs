namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public interface IPsu : IBuilderDirector<IPsuBuilder>, IHasName
{
    public int PeakLoad { get; }
}