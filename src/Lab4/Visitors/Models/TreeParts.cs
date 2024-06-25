namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;

public record TreeParts
{
    private TreeParts()
    {
    }

    public sealed record DirectoryPart(string Indent, string Name) : TreeParts;

    public sealed record FilePart(string Indent, string Name) : TreeParts;
}