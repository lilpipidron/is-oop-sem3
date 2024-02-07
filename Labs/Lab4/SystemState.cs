using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class SystemState
{
    private readonly string _rootPath;

    public SystemState(string rootPath, IFileSystem fileSystem)
    {
        _rootPath = rootPath;
        RelativePath = _rootPath;
        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; }
    public string RelativePath { get; private set; }

    public void SetNewPath(string newRootPath)
    {
        RelativePath = FileSystem.GetRootPath(newRootPath, RelativePath);
    }
}