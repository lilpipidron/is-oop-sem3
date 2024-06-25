using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public interface IDisplayDriver
{
    void ClearOutput();
    void SetModifier(ITextModifier textModifier);
    void PrintMessage(string message);
}