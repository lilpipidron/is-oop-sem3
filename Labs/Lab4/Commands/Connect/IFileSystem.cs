using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect;

public interface IFileSystem
{
    IEnumerable<TreeParts> TreeList(string path, int depth);
    CommandResult FileShow(string path);
    CommandResult FileMove(string sourcePath, string destinationPath);
    CommandResult FileCopy(string sourcePath, string destinationPath);
    CommandResult FileDelete(string path);
    CommandResult FileRename(string path, string name);
    string GetRootPath(string path, string rootPath);
    bool FileExist(string path);
    bool DirectoryExist(string? path);
    string? GetDirectoryName(string path);
    string PathCombine(string path1, string path2);
}