namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

public class VideoCartDimension : IVideoCardDimension
{
    public VideoCartDimension(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public int Height { get; }
    public int Width { get; }
}