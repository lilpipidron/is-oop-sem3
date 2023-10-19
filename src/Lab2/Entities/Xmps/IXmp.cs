namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

public interface IXmp : IBuilderDirector<IXmpBuilder>, IHasName
{
    public string Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}