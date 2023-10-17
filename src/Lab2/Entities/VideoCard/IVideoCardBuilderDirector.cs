namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public interface IVideoCardBuilderDirector
{
    IVideoCardBuilder Director(IVideoCardBuilder builder);
}