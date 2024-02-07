using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.Tree;

public class TreeListHandle : ParserMainChainBase<TreeListContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("list", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        var treeListContextBuilder = new TreeListContext.Builder();
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, treeListContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<TreeListContext.Builder> resSuccess:
                    treeListContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        TreeListContext treeListContext = treeListContextBuilder.Build();
        return new MainParseResult.Success(new TreeList(treeListContext));
    }
}