using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(string socket);

    IMotherboardBuilder WithPciE(int pciE);

    IMotherboardBuilder WithSata(int sata);

    IMotherboardBuilder WithChipset(IChipset chipset);

    IMotherboardBuilder WithDdrStandard(int ddrStandard);

    IMotherboardBuilder WithRamCapacity(int ramCapacity);

    IMotherboardBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor);

    IMotherboardBuilder WithBios(IBios bios);

    IMotherboard Build();
}