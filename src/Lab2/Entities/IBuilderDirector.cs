namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IBuilderDirector<T>
{
    T Director(T builder);
}