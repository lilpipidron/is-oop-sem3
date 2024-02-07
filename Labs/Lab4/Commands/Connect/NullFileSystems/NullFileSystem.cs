using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.NullFileSystems;

public class NullFileSystem : IFileSystem
{
    public IEnumerable<TreeParts> TreeList(string path, int depth)
    {
        return new List<TreeParts>();
    }

    public CommandResult FileShow(string path)
    {
        return new CommandResult.Failed("No file system.\n");
    }

    public CommandResult FileMove(string sourcePath, string destinationPath)
    {
        return new CommandResult.Failed("No file system.\n");
    }

    public CommandResult FileCopy(string sourcePath, string destinationPath)
    {
        return new CommandResult.Failed("No file system.\n");
    }

    public CommandResult FileDelete(string path)
    {
        return new CommandResult.Failed("No file system.\n");
    }

    public CommandResult FileRename(string path, string name)
    {
        return new CommandResult.Failed("No file system.\n");
    }

    public string GetRootPath(string path, string rootPath)
    {
        return string.Empty;
    }

    public bool FileExist(string path)
    {
        return true;
    }

    public bool DirectoryExist(string? path)
    {
        return true;
    }

    public string? GetDirectoryName(string path)
    {
        return string.Empty;
    }

    public string PathCombine(string path1, string path2)
    {
        return string.Empty;
    }
}