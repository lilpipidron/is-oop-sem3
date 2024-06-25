using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;

public class UnknownFileCommandHandle<TBuilder> : ParserMainChainBase<TBuilder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        return new MainParseResult.Failed($"Unknown file command: {requestHandle.Value.Current()}.\n Check and try again.\n");
    }
}