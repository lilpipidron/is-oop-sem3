namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;

public interface IPsu : IPsuBuilderDirector, IHasName
{
    public int PeakLoad { get; }
}