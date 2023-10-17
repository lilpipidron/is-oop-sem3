namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoardBuilderDirector
{
    IMotherBoardBuilder Director(IMotherBoardBuilder builder);
}