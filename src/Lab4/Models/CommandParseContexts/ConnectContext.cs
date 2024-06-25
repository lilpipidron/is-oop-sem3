using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

[GenerateBuilder]
public partial record ConnectContext(
    string Address,
    IFileSystem FileSystem) : CommandParsedContext;