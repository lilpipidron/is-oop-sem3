namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public class CaseDimension : ICaseDimension
{
    public CaseDimension(int height, int width, int depth)
    {
        Height = height;
        Width = width;
        Depth = depth;
    }

    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }
}