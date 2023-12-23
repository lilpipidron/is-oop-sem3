using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;

public class Ram : IRam
{
    internal Ram(
        int amount,
        RamFormFactor ramFormFactor,
        int versionDdr,
        int powerConsumption,
        Jedec jedecProfile,
        Xmp? xmpProfile,
        int amountBoards)
    {
        Amount = amount;
        RamFormFactor = ramFormFactor;
        VersionDdr = versionDdr;
        PowerConsumption = powerConsumption;
        JedecProfile = jedecProfile;
        XmpProfile = xmpProfile;
        AmountBoards = amountBoards;
    }

    public int Amount { get; }
    public RamFormFactor RamFormFactor { get; }
    public int VersionDdr { get; }
    public int PowerConsumption { get; }
    public Jedec JedecProfile { get; }
    public Xmp? XmpProfile { get; }
    public int AmountBoards { get; }

    public IRamBuilder Director(IRamBuilder builder)
    {
        builder
            .WithAmount(Amount)
            .WithRamFormFactor(RamFormFactor)
            .WithVersionDdr(VersionDdr)
            .WithPowerConsumption(PowerConsumption)
            .WithJedec(JedecProfile)
            .WithXmpProfiles(XmpProfile)
            .WithAmountBoards(AmountBoards);

        return builder;
    }
}