using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var df = new Deflector2();
        df.AddPhotonDeflector();
        var sp = new Space();
        sp.AddAsteroid();
        df.GetDamage(new Asteroid());
    }
}