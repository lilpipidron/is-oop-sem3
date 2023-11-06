using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IMessage
{
    public Message(string title, string body, int importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public string Title { get; }
    public string Body { get; }
    public int ImportanceLevel { get; }

    public bool Equals(IMessage? other)
    {
        return Title == other?.Title && Body.Equals(other.Body, StringComparison.Ordinal) && ImportanceLevel == other.ImportanceLevel;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Body, ImportanceLevel);
    }
}