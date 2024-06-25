using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagHandle;

public class FlagDTreeList : ParserFlagChainBase<TreeListContext.Builder>
{
    public override FlagParseResult? Handle(RequestHandle request, TreeListContext.Builder builder)
    {
        if (request.Value.Current().Equals("-d", StringComparison.Ordinal) is false)
            return Next?.Handle(request, builder);
        return request.Value.MoveNext() is false ?
            new FlagParseResult.Failed($"Not enough arguments: -m 'Depth (is number)'\n")
            : AdditionalChain?.Handle(request, builder);
    }
}