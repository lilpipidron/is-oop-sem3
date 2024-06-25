using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.NullFileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Parser
{
    private readonly IParserMainChain _mainChain;
    private SystemState _systemState;

    public Parser(IParserMainChain mainChain)
    {
        _mainChain = mainChain;
        IFileSystem fileSystem = new NullFileSystem();
        _systemState = new SystemState(string.Empty, fileSystem);
    }

    public void StartParse()
    {
        while (true)
        {
            string? command = Console.ReadLine();
            if (command is null)
                continue;

            var request = new RequestHandle(new CommandIterator(command));
            MainParseResult? parseResult = _mainChain.Handle(request);
            switch (parseResult)
            {
                case null:
                    continue;
                case MainParseResult.Failed failedParse:
                    Console.Write(failedParse.Reason);
                    continue;
                case MainParseResult.Success successParse:
                {
                    CommandResult commandResult = successParse.Command.Execute(_systemState);
                    switch (commandResult)
                    {
                        case CommandResult.Failed commandFailed:
                            Console.Write(commandFailed.Problem);
                            continue;
                        case CommandResult.SystemStateChanged systemStateChanged:
                            _systemState = systemStateChanged.SystemState;
                            break;
                    }

                    break;
                }
            }
        }
    }
}