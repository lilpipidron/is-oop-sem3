using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;

public interface IParserMainChain
{
    void AddNext(IParserMainChain parserMainChain);
    MainParseResult? Handle(RequestHandle requestHandle);
}