namespace Common.Library.Core.Unit.Test.Specs.ValueObject;

using System.Collections.Generic;
using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "ValueObject")]
public class ValueObjectShould
{
	[Fact(DisplayName = "ValueObject operator equality between two ValueObjects return equals")]
	public void ValueObject_OperatorEqualityBetweenTwoValueObjects_ReturnEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var result = left == right;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "ValueObject operator equality between two ValueObjects return no equals")]
	public void ValueObject_OperatorEqualityBetweenTwoValueObjects_ReturnNoEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyValueObject
		{
			Name = "test",
			Value = 1
		};

		var result = left == right;

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "ValueObject operator distinct between two ValueObjects return equals")]
	public void ValueObject_OperatorDistinctBetweenTwoValueObjects_ReturnEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var result = left != right;

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "ValueObject operator distinct between two ValueObjects return no equals")]
	public void ValueObject_OperatorDistinctBetweenTwoValueObjects_ReturnNoEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyValueObject
		{
			Name = "test",
			Value = 1
		};

		var result = left != right;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "ValueObject equality between two ValueObjects return equals")]
	public void ValueObject_EqualityBetweenTwoValueObjects_ReturnEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var result = left.Equals(right);

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "ValueObject equality between two ValueObjects return no equals")]
	public void ValueObject_EqualityBetweenTwoValueObjects_ReturnNoEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyValueObject
		{
			Name = "test",
			Value = 1
		};

		var result = left.Equals(right);

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "ValueObject equality between two distinct ValueObjects return no equals")]
	public void ValueObject_EqualityBetweenTwoDistinctValueObjects_ReturnNoEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};
		var right = new DummyOtherValueObject
		{
			Name = "test"
		};

		left.Equals(right).Should().BeFalse();
	}

	[Fact(DisplayName = "ValueObject equality ValueObjects with null return no equals")]
	public void ValueObject_EqualityValueObjectsWithNull_ReturnNoEquals()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var result = left.Equals(null);

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "ValueObject two ValueObject get hashcode return same hashcode")]
	public void ValueObject_TwoValueObjectsGetHashCode_ReturnSameHashCode()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var right = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var leftHash = left.GetHashCode();
		var rightHash = right.GetHashCode();

		leftHash.Should().Be(rightHash);
	}

	[Fact(DisplayName = "ValueObject two ValueObject get hashcode return distinct hashcode")]
	public void ValueObject_TwoValueObjectsGetHashCode_ReturnDistinctHashCode()
	{
		var left = new DummyValueObject
		{
			Name = "test",
			Value = 0
		};

		var right = new DummyValueObject
		{
			Name = "test",
			Value = 1
		};

		var leftHash = left.GetHashCode();
		var rightHash = right.GetHashCode();

		leftHash.Should().NotBe(rightHash);
	}

	private class DummyValueObject : ValueObject<DummyValueObject>
	{
		public string Name { get; set; }

		public int Value { get; set; }

		protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
		{
			yield return Name;
			yield return Value;
		}
	}

	private class DummyOtherValueObject : ValueObject<DummyOtherValueObject>
	{
		public string Name { get; set; }

		protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
		{
			yield return Name;
		}
	}
}