namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public interface ICoolingSystemBuilderDirector
{
    ICoolingSystemBuilder Director(ICoolingSystemBuilder builder);
}