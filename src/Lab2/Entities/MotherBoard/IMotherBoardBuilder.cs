using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder WithSocket(string socket);
    IMotherBoardBuilder WithPciE(int pciE);
    IMotherBoardBuilder WithSata(int sata);
    IMotherBoardBuilder WithChipset(IChipset chipset);
    IMotherBoardBuilder WithDdrStandard(int ddrStandard);
    IMotherBoardBuilder WithRamCapacity(int ramCapacity);
    IMotherBoardBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor);
    IMotherBoardBuilder WithBios(IBios bios);
}