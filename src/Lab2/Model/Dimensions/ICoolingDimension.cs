namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public interface ICoolingDimension : IDimension
{
    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }
}