namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCardBuilderDirector
{
    IVideoCardBuilder Director(IVideoCardBuilder builder);
}