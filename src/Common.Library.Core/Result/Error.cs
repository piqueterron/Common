namespace Common.Library.Core;

using System;

public readonly record struct Error
{
    public string Description { get; init; }

    public Exception Exception { get; init; }

    private Error(string description, Exception exception = null)
    {
        Description = description;
        Exception = exception;
    }

    private Error(string description)
    {
        Description = description;
        Exception = null;
    }

    public static Error Create(string description, Exception value) =>
        new(description, value);

    public static Error Create(string description) =>
        new(description);
}