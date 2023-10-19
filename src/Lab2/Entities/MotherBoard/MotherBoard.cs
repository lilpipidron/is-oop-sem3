using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoard : IMotherBoard
{
    internal MotherBoard(
        string name,
        string socket,
        int pciE,
        int sata,
        IChipset chipset,
        int ddrStandard,
        int ramCapacity,
        MotherBoardFormFactor motherBoardFormFactor,
        IBios bios)
    {
        Name = name;
        Socket = socket;
        PciE = pciE;
        Sata = sata;
        Chipset = chipset;
        DdrStandard = ddrStandard;
        RamCapacity = ramCapacity;
        MotherBoardFormFactor = motherBoardFormFactor;
        Bios = bios;
    }

    public string Name { get; }
    public string Socket { get; }
    public int PciE { get; }
    public int Sata { get; }
    public IChipset Chipset { get; }
    public int DdrStandard { get; }
    public int RamCapacity { get; }
    public MotherBoardFormFactor MotherBoardFormFactor { get; }
    public IBios Bios { get; }

    public IMotherBoardBuilder Director(IMotherBoardBuilder builder)
    {
        builder
            .WithName(Name)
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