namespace Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

public record MotherBoardFormFactor
{
    private MotherBoardFormFactor()
    {
    }

    public sealed record StandartMotherBoardForm : MotherBoardFormFactor;

    public sealed record MiniMotherBoardForm : MotherBoardFormFactor;

    public sealed record LowProfileMotherBoardForm : MotherBoardFormFactor;
}