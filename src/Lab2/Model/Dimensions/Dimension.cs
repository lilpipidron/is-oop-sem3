namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public record Dimension
{
    private Dimension()
    {
    }

    public sealed record CoolingDimension(int Height, int Width, int Depth);

    public sealed record CaseDimension(int Height, int Width, int Depth);

    public sealed record VideoCardDimension(int Height, int Width);
}