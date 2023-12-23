namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;

public interface IJedec : IPcComponent, IBuilderDirector<IJedecBuilder>
{
    public string Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}