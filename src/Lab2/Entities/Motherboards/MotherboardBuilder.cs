using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public class MotherboardBuilder : IMotherboardBuilder
{
    private PcSocket? _socket;
    private int? _pciE;
    private int? _sata;
    private IChipset? _chipset;
    private int? _ddrStandard;
    private int? _ramCapacity;
    private MotherBoardFormFactor? _motherBoardFormFactor;
    private IBios? _bios;
    private IWiFiAdapter? _wifiAdapter;

    public IMotherboardBuilder WithSocket(PcSocket socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder WithPciE(int pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IMotherboardBuilder WithSata(int sata)
    {
        _sata = sata;
        return this;
    }

    public IMotherboardBuilder WithChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithDdrStandard(int ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherboardBuilder WithRamCapacity(int ramCapacity)
    {
        _ramCapacity = ramCapacity;
        return this;
    }

    public IMotherboardBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor)
    {
        _motherBoardFormFactor = motherBoardFormFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder WithWiFiAdapter(IWiFiAdapter wiFiAdapter)
    {
        _wifiAdapter = wiFiAdapter;
        return this;
    }

    public IMotherboard Build()
    {
        return new Motherboard(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _pciE ?? throw new ArgumentNullException(nameof(_pciE)),
            _sata ?? throw new ArgumentNullException(nameof(_sata)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _ddrStandard ?? throw new ArgumentNullException(nameof(_ddrStandard)),
            _ramCapacity ?? throw new ArgumentNullException(nameof(_ramCapacity)),
            _motherBoardFormFactor ?? throw new ArgumentNullException(nameof(_motherBoardFormFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _wifiAdapter);
    }
}