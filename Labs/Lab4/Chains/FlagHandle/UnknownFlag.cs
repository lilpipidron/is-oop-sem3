using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagHandle;

public class UnknownFlag<TBuilder> : ParserFlagChainBase<TBuilder>
{
    public override FlagParseResult? Handle(RequestHandle request, TBuilder builder)
    {
        return new FlagParseResult.Failed($"Unknown flag: {request.Value.Current()}\n");
    }
}