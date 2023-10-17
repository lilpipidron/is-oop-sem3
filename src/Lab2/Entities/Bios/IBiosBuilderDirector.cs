namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;

public interface IBiosBuilderDirector
{
    IBiosBuilder Director(IBiosBuilder builder);
}