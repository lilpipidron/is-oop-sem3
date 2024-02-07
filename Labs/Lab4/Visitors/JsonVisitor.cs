using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;
using Microsoft.Extensions.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class JsonVisitor
{
    private readonly IConfigurationRoot _icons;

    public JsonVisitor()
    {
        _icons = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables()
            .Build();
    }

    public string Visit(IEnumerable<TreeParts> tree)
    {
        string output = string.Empty;
        foreach (TreeParts treePart in tree)
        {
            switch (treePart)
            {
                case TreeParts.DirectoryPart directoryPart:
                    output += directoryPart.Indent + "|—" + _icons["Directory"] + directoryPart.Name + Environment.NewLine;
                    continue;
                case TreeParts.FilePart filePart:
                    output += filePart.Indent + "|—" + _icons["File"] + filePart.Name + Environment.NewLine;
                    break;
            }
        }

        return output;
    }
}

// ($"{new string(' ', 4 * currentDepth)}{icon}|—{Path.GetFileName(path)}");