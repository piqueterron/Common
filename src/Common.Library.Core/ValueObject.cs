namespace Common.Library.Core;

public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
	where T : notnull, ValueObject<T>
{
	public static bool operator ==(ValueObject<T> left, ValueObject<T> right) =>
		Equals(left, right);

	public static bool operator !=(ValueObject<T> left, ValueObject<T> right) =>
		!(left == right);

	protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

	public override bool Equals(object other) =>
		Equals(other as ValueObject<T>);

	public override int GetHashCode()
	{
		unchecked
		{
			var hash = 13;

			foreach (var obj in GetAttributesToIncludeInEqualityCheck())
			{
				hash = hash * 7 ^ (obj is null ? 0 : obj.GetHashCode());
			}

			return hash;
		}
	}

	public bool Equals(ValueObject<T> other)
	{
		if (other is null)
		{
			return false;
		}

		return GetAttributesToIncludeInEqualityCheck().SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
	}
}