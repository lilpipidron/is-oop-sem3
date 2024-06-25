using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public class PcCase : IPcCase
{
    internal PcCase(
        int videoCardHeight,
        int videoCardWidth,
        IEnumerable<MotherBoardFormFactor> motherBoardForms,
        int height,
        int width,
        int depth)
    {
        VideoCardHeight = videoCardHeight;
        VideoCardWidth = videoCardWidth;
        MotherBoardForms = motherBoardForms.ToArray();
        Height = height;
        Width = width;
        Depth = depth;
    }

    public int VideoCardHeight { get; }
    public int VideoCardWidth { get; }
    public IReadOnlyCollection<MotherBoardFormFactor> MotherBoardForms { get; }
    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }

    public IPcCaseBuilder Director(IPcCaseBuilder builder)
    {
        builder
            .WithMaxVideoCardDimension(VideoCardHeight, VideoCardWidth)
            .WithMotherBoardForms(MotherBoardForms)
            .WithDimension(Height, Width, Depth);

        return builder;
    }
}