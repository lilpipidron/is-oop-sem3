using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public class Xmp : IXmp
{
     private readonly int[] _timings;
     private readonly int _voltage;
     private readonly int _frequency;

     public Xmp(string timings, int voltage, int frequency)
     {
          _timings = Array.ConvertAll(timings.Split('-'), int.Parse);
          _voltage = voltage;
          _frequency = frequency;
     }
}