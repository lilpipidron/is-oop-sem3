using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.Tree;

public class TreeHandle : ParserMainChainBase<int>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("tree", StringComparison.Ordinal) is false)
        {
            return Next?.Handle(requestHandle);
        }

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("No enough arguments.\n");
        return AdditionalChain?.Handle(requestHandle);
    }
}