using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public class Motherboard : IMotherboard
{
    internal Motherboard(
        PcSocket socket,
        int pciE,
        int sata,
        IChipset chipset,
        int ddrStandard,
        int ramCapacity,
        MotherBoardFormFactor motherBoardFormFactor,
        IBios bios)
    {
        Socket = socket;
        PciE = pciE;
        Sata = sata;
        Chipset = chipset;
        DdrStandard = ddrStandard;
        RamCapacity = ramCapacity;
        MotherBoardFormFactor = motherBoardFormFactor;
        Bios = bios;
    }

    public PcSocket Socket { get; }
    public int PciE { get; }
    public int Sata { get; }
    public IChipset Chipset { get; }
    public int DdrStandard { get; }
    public int RamCapacity { get; }
    public MotherBoardFormFactor MotherBoardFormFactor { get; }
    public IBios Bios { get; }

    public IMotherboardBuilder Director(IMotherboardBuilder builder)
    {
        builder
            .WithSocket(Socket)
            .WithPciE(PciE)
            .WithSata(Sata)
            .WithChipset(Chipset)
            .WithDdrStandard(DdrStandard)
            .WithRamCapacity(RamCapacity)
            .WithMotherBoardFormFactor(MotherBoardFormFactor)
            .WithBios(Bios);

        return builder;
    }
}