using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Iterators;

public class CommandIterator : IIterator
{
    private readonly IReadOnlyCollection<string> _commands;
    private int _position;

    public CommandIterator(string commands)
    {
        _commands = commands.Split(' ');
    }

    public bool MoveNext()
    {
        _position++;
        return _position < _commands.Count;
    }

    public string Current()
    {
        return _commands.ElementAt(_position);
    }
}