namespace Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

public record MotherBoardFormFactor
{
    private MotherBoardFormFactor()
    {
    }

    public sealed record EAtx : MotherBoardFormFactor;

    public sealed record StandartAtx : MotherBoardFormFactor;

    public sealed record MicroAtx : MotherBoardFormFactor;

    public sealed record MiniDtx : MotherBoardFormFactor;

    public sealed record MiniItx : MotherBoardFormFactor;
}