namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboardBuilderDirector
{
    IMotherboardBuilder Director(IMotherboardBuilder builder);
}