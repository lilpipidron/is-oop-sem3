using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;

public interface IParserFlagChain<TBuilder>
{
    void AddNext(IParserFlagChain<TBuilder> parserFlagChain);
    FlagParseResult? Handle(RequestHandle request, TBuilder builder);
}