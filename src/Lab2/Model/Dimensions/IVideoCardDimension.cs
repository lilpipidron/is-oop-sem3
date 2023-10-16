namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public interface IVideoCardDimension : IDimension
{
    public int Height { get; }
    public int Width { get; }
}