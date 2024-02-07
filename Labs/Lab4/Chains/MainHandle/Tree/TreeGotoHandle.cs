using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.Tree;

public class TreeGotoHandle : ParserMainChainBase<TreeGotoContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("goto", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Not enough arguments: tree goto [Path]\n");
        string path = requestHandle.Value.Current();
        TreeGotoContext.Builder treeGotoContextBuilder = new TreeGotoContext.Builder().WithPath(path);
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, treeGotoContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<TreeGotoContext.Builder> resSuccess:
                    treeGotoContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        TreeGotoContext treeGotoContext;
        try
        {
            treeGotoContext = treeGotoContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Not enough arguments: tree goto [Path]\n");
        }

        return new MainParseResult.Success(new TreeGoto(treeGotoContext));
    }
}