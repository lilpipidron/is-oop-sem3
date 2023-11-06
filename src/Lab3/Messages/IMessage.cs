using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage : IEquatable<IMessage>
{
    public string Title { get; }
    public string Body { get; }
    public int ImportanceLevel { get; }
}