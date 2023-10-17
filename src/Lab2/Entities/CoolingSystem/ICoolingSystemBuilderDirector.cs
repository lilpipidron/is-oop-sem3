namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public interface ICoolingSystemBuilderDirector
{
    ICoolingSystemBuilder Director(ICoolingSystemBuilder builder);
}