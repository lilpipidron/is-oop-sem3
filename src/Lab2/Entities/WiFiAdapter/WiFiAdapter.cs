namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapter : IWiFiAdapter
{
    internal WiFiAdapter(string name, int wifiVersion, bool bluetooth, string versionPciE, int powerConsumption)
    {
        Name = name;
        WifiVersion = wifiVersion;
        Bluetooth = bluetooth;
        VersionPciE = versionPciE;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int WifiVersion { get; }
    public bool Bluetooth { get; }
    public string VersionPciE { get; }
    public int PowerConsumption { get; }

    public IWiFiBuilder Director(IWiFiBuilder builder)
    {
        builder
            .WithName(Name)
            .WithWiFiVersion(WifiVersion)
            .WithBluetooth(Bluetooth)
            .WithVersionPciE(VersionPciE)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}