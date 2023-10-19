using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;

public interface ICpuBuilderDirector
{
    ICpuBuilder Director(ICpuBuilder builder);
}