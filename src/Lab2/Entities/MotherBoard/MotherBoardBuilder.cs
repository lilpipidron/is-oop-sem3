using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private string? _socket;
    private int? _pciE;
    private int? _sata;
    private IChipset? _chipset;
    private int? _ddrStandard;
    private int? _ramCapacity;
    private MotherBoardFormFactor? _motherBoardFormFactor;
    private IBios? _bios;

    public IMotherBoardBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherBoardBuilder WithPciE(int pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IMotherBoardBuilder WithSata(int sata)
    {
        _sata = sata;
        return this;
    }

    public IMotherBoardBuilder WithChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherBoardBuilder WithDdrStandard(int ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherBoardBuilder WithRamCapacity(int ramCapacity)
    {
        _ramCapacity = ramCapacity;
        return this;
    }

    public IMotherBoardBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor)
    {
        _motherBoardFormFactor = motherBoardFormFactor;
        return this;
    }

    public IMotherBoardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherBoard Build()
    {
        return new MotherBoard(
            _socket ?? throw new System.ArgumentNullException(nameof(_socket)),
            _pciE ?? throw new System.ArgumentNullException(nameof(_pciE)),
            _sata ?? throw new System.ArgumentNullException(nameof(_sata)),
            _chipset ?? throw new System.ArgumentNullException(nameof(_chipset)),
            _ddrStandard ?? throw new System.ArgumentNullException(nameof(_ddrStandard)),
            _ramCapacity ?? throw new System.ArgumentNullException(nameof(_ramCapacity)),
            _motherBoardFormFactor ?? throw new System.ArgumentNullException(nameof(_motherBoardFormFactor)),
            _bios ?? throw new System.ArgumentNullException(nameof(_bios)));
    }
}