namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;

public interface IIvcBuilder
{
    IIvcBuilder WithTdp(int tdp);

    IIvcBuilder WithMemoryAmount(int memoryAmount);

    IIvcBuilder WithClockFrequency(int clockFrequency);

    IIvc Build();
}