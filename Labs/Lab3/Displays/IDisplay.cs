using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    PrintResult PrintMessage(ITextModifier modifier, string message);
}