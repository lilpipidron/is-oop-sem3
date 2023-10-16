using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoard : IMotherBoard
{
    private readonly string _socket;
    private readonly int _pciE;
    private readonly int _sata;
    private readonly IChipset _chipset;
    private readonly int _ddrStandard;
    private readonly int _ramCapacity;
    private readonly MotherBoardFormFactor _motherBoardFormFactor;
    private readonly IBios _bios;

    public MotherBoard(
        string socket,
        int pciE,
        int sata,
        IChipset chipset,
        int ddrStandard,
        int ramCapacity,
        MotherBoardFormFactor motherBoardFormFactor,
        IBios bios)
    {
        _socket = socket;
        _pciE = pciE;
        _sata = sata;
        _chipset = chipset;
        _ddrStandard = ddrStandard;
        _ramCapacity = ramCapacity;
        _motherBoardFormFactor = motherBoardFormFactor;
        _bios = bios;
    }
}