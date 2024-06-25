using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

public class TextColorModifier : ITextModifier
{
    private readonly Color? _color;

    public TextColorModifier(Color? color)
    {
        _color = color;
    }

    public string Modify(string value)
    {
        if (_color is null)
        {
            return value;
        }

        Color color = _color.GetValueOrDefault();
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(value);
    }
}