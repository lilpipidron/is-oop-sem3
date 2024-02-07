using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;

public class FileCopyHandle : ParserMainChainBase<FileCopyContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("copy", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file copy [SourcePath] [DestinationPath]\n");
        string sourcePath = requestHandle.Value.Current();

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file copy [SourcePath] [DestinationPath]\n");
        string destinationPath = requestHandle.Value.Current();
        FileCopyContext.Builder fileCopyContextBuilder = new FileCopyContext.Builder().WithSourcePath(sourcePath).WithDestinationPath(destinationPath);
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, fileCopyContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<FileCopyContext.Builder> resSuccess:
                    fileCopyContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        FileCopyContext fileCopyContext;
        try
        {
            fileCopyContext = fileCopyContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Not enough arguments: file copy [SourcePath] [DestinationPath]\n");
        }

        return new MainParseResult.Success(new FileCopy(fileCopyContext));
    }
}