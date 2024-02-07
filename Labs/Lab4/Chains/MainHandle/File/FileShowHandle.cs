using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;

public class FileShowHandle : ParserMainChainBase<FileShowContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("show", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file show [Path]\n");
        string path = requestHandle.Value.Current();

        FileShowContext.Builder fileShowContextBuilder =
            new FileShowContext.Builder().WithPath(path);

        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, fileShowContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<FileShowContext.Builder> resSuccess:
                    fileShowContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        FileShowContext fileShowContext;
        try
        {
            fileShowContext = fileShowContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Not enough arguments: file show [Path]\n");
        }

        return new MainParseResult.Success(new FileShow(fileShowContext));
    }
}