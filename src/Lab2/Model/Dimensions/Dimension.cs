namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public record Dimension
{
    private Dimension()
    {
    }

    public record HWDDimension(int Height, int Width, int Depth) : Dimension
    {
        public bool IsCompatible(HWDDimension dimension)
        {
            return Height >= dimension.Height &&
                   Width >= dimension.Width &&
                   Depth >= dimension.Height;
        }
    }

    public record HWDimension(int Height, int Width) : Dimension
    {
        public bool IsCompatible(HWDimension dimension)
        {
            return Height >= dimension.Height &&
                   Width >= dimension.Width;
        }
    }
}