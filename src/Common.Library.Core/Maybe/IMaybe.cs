namespace Common.Library.Core;

public interface IMaybe<out T>
    where T : notnull
{
    bool HasValue { get; }

    T Value { get; }
}