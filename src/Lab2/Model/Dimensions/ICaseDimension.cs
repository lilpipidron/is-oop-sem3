namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public interface ICaseDimension : IDimension
{
    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }
}