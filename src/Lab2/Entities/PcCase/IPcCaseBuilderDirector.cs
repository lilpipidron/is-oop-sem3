namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCase;

public interface IPcCaseBuilderDirector
{
    IPcCaseBuilder Director(IPcCaseBuilder builder);
}