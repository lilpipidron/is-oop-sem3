using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public interface ICpu : ICpuBuilderDirector, IHasName
{
    public double CoreFrequency { get; }
    public double CoreAmount { get; }
    public string Socket { get; }
    public bool VideoCore { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }
}