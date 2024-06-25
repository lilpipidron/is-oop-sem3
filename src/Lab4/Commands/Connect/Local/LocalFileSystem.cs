using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Local;

public class LocalFileSystem : IFileSystem
{
    public CommandResult FileMove(string sourcePath, string destinationPath)
    {
        try
        {
            File.Move(sourcePath, destinationPath);
            return new CommandResult.Success();
        }
        catch (Exception)
        {
            return new CommandResult.Failed("Command file move failed.\n");
        }
    }

    public CommandResult FileCopy(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, destinationPath, true);
            return new CommandResult.Success();
        }
        catch (Exception)
        {
            return new CommandResult.Failed($"Command file copy failed.\n");
        }
    }

    public CommandResult FileDelete(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (Exception)
        {
            return new CommandResult.Failed($"Command file delete failed.\n");
        }

        return new CommandResult.Success();
    }

    public CommandResult FileRename(string path, string name)
    {
        try
        {
            File.Move(path, name);
            return new CommandResult.Success();
        }
        catch (Exception)
        {
            return new CommandResult.Failed($"Command file rename failed\n");
        }
    }

    public IEnumerable<TreeParts> TreeList(string path, int depth)
    {
        return Traversal(path, depth, 0, new List<TreeParts>());
    }

    public CommandResult FileShow(string path)
    {
        try
        {
            string file = File.ReadAllText(path);
            return new CommandResult.OutputResult(file);
        }
        catch (Exception)
        {
            return new CommandResult.Failed($"Command file show failed.\n");
        }
    }

    public string GetRootPath(string path, string rootPath)
    {
        if (Path.IsPathRooted(path)) return path;
        return rootPath + '/' + path;
    }

    public bool DirectoryExist(string? path)
    {
        return Directory.Exists(path);
    }

    public bool FileExist(string path)
    {
        return File.Exists(path);
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public string PathCombine(string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }

    private IEnumerable<TreeParts> Traversal(string path, int depth, int currentDepth, IEnumerable<TreeParts> treeState)
    {
        var tree = treeState.ToList();
        if (currentDepth > depth)
            return tree;
        if (File.Exists(path) is false)
        {
            tree.Add(new TreeParts.DirectoryPart(new string(' ', 4 * currentDepth), Path.GetFileName(path)));
        }
        else
        {
            tree.Add(new TreeParts.FilePart(new string(' ', 4 * currentDepth), Path.GetFileName(path)));
        }

        if (Directory.Exists(path) is false)
            return tree;

        foreach (string subPath in Directory.GetFileSystemEntries(path))
        {
            tree = Traversal(subPath, depth, currentDepth + 1, tree).ToList();
        }

        return tree;
    }
}