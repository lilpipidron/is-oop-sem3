namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public interface IPcCaseBuilderDirector
{
    IPcCaseBuilder Director(IPcCaseBuilder builder);
}