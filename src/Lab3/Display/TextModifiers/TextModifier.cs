using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.TextModifiers;

public class TextModifier : ITextModifier
{
    private readonly Color? _color;

    public TextModifier(Color? color)
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