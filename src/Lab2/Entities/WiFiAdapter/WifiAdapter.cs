namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WifiAdapter
{
    private readonly int _wifiVersion;
    private readonly bool _bluetooth;
    private readonly string _versionPciE;
    private readonly int _powerConsumption;

    public WifiAdapter(int wifiVersion, bool bluetooth, string versionPciE, int powerConsumption)
    {
        _wifiVersion = wifiVersion;
        _bluetooth = bluetooth;
        _versionPciE = versionPciE;
        _powerConsumption = powerConsumption;
    }
}