using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboard : IBuilderDirector<IMotherboardBuilder>, IPcComponent
{
    public PcSocket Socket { get; }
    public int PciE { get; }
    public int Sata { get; }
    public IChipset Chipset { get; }
    public int DdrStandard { get; }
    public int RamCapacity { get; }
    public MotherBoardFormFactor MotherBoardFormFactor { get; }
    public IBios Bios { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
}