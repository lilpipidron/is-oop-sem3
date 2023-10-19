using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;

public class WiFiBuilder : IWiFiBuilder
{
    private string? _name;
    private int? _wifiVersion;
    private bool _bluetooth;
    private string? _versionPciE;
    private int? _powerConsumption;

    public IWiFiBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWiFiBuilder WithWiFiVersion(int wifiVersion)
    {
        _wifiVersion = wifiVersion;
        return this;
    }

    public IWiFiBuilder WithBluetooth(bool bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public IWiFiBuilder WithVersionPciE(string versionPciE)
    {
        _versionPciE = versionPciE;
        return this;
    }

    public IWiFiBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapters.WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _wifiVersion ?? throw new ArgumentNullException(nameof(_wifiVersion)),
            _bluetooth,
            _versionPciE ?? throw new ArgumentNullException(nameof(_versionPciE)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}