namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public record Dimension
{
    private Dimension()
    {
    }

    public record CoolingDimension(int Height, int Width, int Depth) : Dimension;

    public record CaseDimension(int Height, int Width, int Depth) : Dimension;

    public record VideoCardDimension(int Height, int Width) : Dimension
    {
        public bool IsCompatible(VideoCardDimension dimension)
        {
            return Height >= dimension.Height && Width >= dimension.Width;
        }
    }
}