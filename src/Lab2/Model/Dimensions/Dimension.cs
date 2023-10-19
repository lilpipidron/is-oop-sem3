namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public record Dimension
{
    private Dimension()
    {
    }

    public record CoolingDimension(int Height, int Width, int Depth);

    public record CaseDimension(int Height, int Width, int Depth);

    public record VideoCardDimension(int Height, int Width);
}