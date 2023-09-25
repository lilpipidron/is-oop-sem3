using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var df = new Deflector2();
        df.AddPhotonDeflector();
        df.GetDamage(new Asteroid(100, 100));
    }
}