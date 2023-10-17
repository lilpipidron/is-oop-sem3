namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public interface ICpuBuilderDirector
{
    ICpuBuilder Director(ICpuBuilder builder);
}