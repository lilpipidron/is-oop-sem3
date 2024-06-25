using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;

public class FileMoveHandle : ParserMainChainBase<FileMoveContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("move", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file move [SourcePath] [DestinationPath]\n");
        string sourcePath = requestHandle.Value.Current();

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: file move [SourcePath] [DestinationPath]\n");
        string destinationPath = requestHandle.Value.Current();
        FileMoveContext.Builder fileMoveContextBuilder = new FileMoveContext.Builder().WithSourcePath(sourcePath)
            .WithDestinationPath(destinationPath);
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, fileMoveContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<FileMoveContext.Builder> resSuccess:
                    fileMoveContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        FileMoveContext fileMoveContext;
        try
        {
            fileMoveContext = fileMoveContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Not enough arguments: file move [SourcePath] [DestinationPath]\n");
        }

        return new MainParseResult.Success(new FileMove(fileMoveContext));
    }
}