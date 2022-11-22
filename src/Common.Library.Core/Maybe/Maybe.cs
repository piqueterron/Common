namespace Common.Library.Core;

public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<object>, IMaybe<T>
{
	public static readonly Maybe<T> None = new();

	public bool HasValue { get; }

	public T Value { get; }

	private Maybe(T value)
	{
		HasValue = !Equals(value, null);
		Value = value;
	}

	public static implicit operator Maybe<T>(T value) =>
		new(value);

	public static bool operator ==(Maybe<T> maybe, T value) =>
		maybe.Value.Equals(value);

	public static bool operator !=(Maybe<T> maybe, T value) =>
		!maybe.Value.Equals(value);

	public static bool operator ==(Maybe<T> first, Maybe<T> second) =>
		first.Equals(second);

	public static bool operator !=(Maybe<T> first, Maybe<T> second) =>
		!(first == second);

	public override bool Equals(object obj)
	{
		if (obj is null)
		{
			return false;
		}
		if (obj is Maybe<T> other)
		{
			return Equals(other);
		}
		if (obj is T value)
		{
			return EqualityComparer<T>.Default.Equals(Value, value);
		}
		return false;
	}

	public bool Equals(Maybe<T> other)
	{
		if (!HasValue && !other.HasValue)
		{
			return true;
		}

		if (!HasValue || !other.HasValue)
		{
			return false;
		}

		return EqualityComparer<T>.Default.Equals(Value, other.Value);
	}

	public override int GetHashCode() =>
		HashCode.Combine(HasValue, Value);
}