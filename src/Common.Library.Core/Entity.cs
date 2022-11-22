namespace Common.Library.Core;

using System;

public abstract class Entity<TKey> : IEquatable<TKey>
{
	protected TKey Id { get; set; }

	public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
	{
		if (Equals(left, null))
		{
			return Equals(right, null);
		}

		return left.Equals(right);
	}

	public static bool operator !=(Entity<TKey> left, Entity<TKey> right) =>
		!(left == right);

	public bool Equals(TKey other) =>
		EqualityComparer<TKey>.Default.Equals(Id, other);

	public override bool Equals(object obj)
	{
		if (obj is not Entity<TKey>)
		{
			return false;
		}

		if (ReferenceEquals(this, obj))
		{
			return true;
		}

		if (GetType() != obj.GetType())
		{
			return false;
		}

		var other = obj as Entity<TKey>;

		return GetHashCode() == other?.GetHashCode();
	}

	public override int GetHashCode()
	{
		unchecked
		{
			var hash = 13;
			hash = hash * 7 ^ Id?.GetHashCode() ?? 0;

			return hash;
		}
	}
}