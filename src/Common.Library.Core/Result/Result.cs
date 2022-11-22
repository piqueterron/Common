namespace Common.Library.Core;

public readonly record struct Result<TValue>
{
    private readonly TValue _value = default;
    private readonly Error? _error = null;

    public readonly bool IsError;

    public TValue Value => _value;

    public Error? Error => _error;

    private Result(TValue value)
    {
        _value = value;
        IsError = false;
    }

    private Result(Error error)
    {
        _error = error;
        IsError = true;
    }

    public static implicit operator Result<TValue>(Error error) => new(error);

    public static implicit operator Result<TValue>(TValue value) => new(value);
}