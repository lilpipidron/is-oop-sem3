using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagArgumentsHandle;

public class Depth : ParserFlagChainBase<TreeListContext.Builder>
{
    public override FlagParseResult? Handle(RequestHandle request, TreeListContext.Builder builder)
    {
        if (request.Value.Current().Equals("local", StringComparison.Ordinal) is false)
            return Next?.Handle(request, builder);
        if (int.TryParse(request.Value.Current(), CultureInfo.InvariantCulture, out int depth) is false)
        {
            return new FlagParseResult.Failed("Parameter depth must be number.\n Check and try again.\n");
        }

        return new FlagParseResult.Success<TreeListContext.Builder>(
            request,
            builder.WithDepth(depth));
    }
}