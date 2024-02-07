using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public class PcCaseBuilder : IPcCaseBuilder
{
    private int? _videoCardHeight;
    private int? _videoCardWidth;
    private IReadOnlyCollection<MotherBoardFormFactor>? _motherBoardForms;
    private int? _height;
    private int? _width;
    private int? _depth;

    public IPcCaseBuilder WithMaxVideoCardDimension(int videoCardHeight, int videoCardWidth)
    {
        _videoCardHeight = videoCardHeight;
        _videoCardWidth = videoCardWidth;
        return this;
    }

    public IPcCaseBuilder WithMotherBoardForms(IEnumerable<MotherBoardFormFactor> motherBoardForms)
    {
        _motherBoardForms = motherBoardForms.ToArray();
        return this;
    }

    public IPcCaseBuilder WithDimension(int height, int width, int depth)
    {
        _height = height;
        _width = width;
        _depth = depth;
        return this;
    }

    public IPcCase Build()
    {
        return new PcCase(
            _videoCardHeight ?? throw new ArgumentNullException(nameof(_videoCardHeight)),
            _videoCardWidth ?? throw new ArgumentNullException(nameof(_videoCardHeight)),
            _motherBoardForms ?? throw new ArgumentNullException(nameof(_motherBoardForms)),
            _height ?? throw new ArgumentNullException(nameof(_height)),
            _width ?? throw new ArgumentNullException(nameof(_width)),
            _depth ?? throw new ArgumentNullException(nameof(_depth)));
    }
}