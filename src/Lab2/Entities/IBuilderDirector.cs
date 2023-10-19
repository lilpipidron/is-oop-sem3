namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IBuilderDirector<T1>
{
    T1 Director(T1 builder);
}