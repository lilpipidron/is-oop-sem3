using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface IFileSystemCommand
{
    CommandResult Execute(SystemState systemState);
}