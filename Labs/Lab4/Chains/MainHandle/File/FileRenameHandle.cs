using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;

public class FileRenameHandle : ParserMainChainBase<FileRenameContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("rename", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file rename [Path] [Name]\n");
        string path = requestHandle.Value.Current();

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file rename [Path] [Name]\n");
        string name = requestHandle.Value.Current();
        FileRenameContext.Builder fileRenameContextBuilder =
            new FileRenameContext.Builder().WithPath(path).WithName(name);

        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, fileRenameContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<FileRenameContext.Builder> resSuccess:
                    fileRenameContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        FileRenameContext fileRenameContext;
        try
        {
            fileRenameContext = fileRenameContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Not enough arguments: file rename [Path] [Name]\n");
        }

        return new MainParseResult.Success(new FileRename(fileRenameContext));
    }
}