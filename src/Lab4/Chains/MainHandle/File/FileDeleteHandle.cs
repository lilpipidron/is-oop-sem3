using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;

public class FileDeleteHandle : ParserMainChainBase<FileDeleteContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("delete", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);
        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file delete [Path]\n");
        string path = requestHandle.Value.Current();
        FileDeleteContext.Builder fileDeleteContextBuilder = new FileDeleteContext.Builder().WithPath(path);
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, fileDeleteContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<FileDeleteContext.Builder> resSuccess:
                    fileDeleteContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        FileDeleteContext fileDeleteContext;
        try
        {
            fileDeleteContext = fileDeleteContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Not enough arguments: file delete [Path]\n");
        }

        return new MainParseResult.Success(new FileDelete(fileDeleteContext));
    }
}