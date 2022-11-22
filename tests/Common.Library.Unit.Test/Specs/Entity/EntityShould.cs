namespace Common.Library.Core.Unit.Test.Specs.Entity;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Entity")]
public class EntityShould
{
	[Fact(DisplayName = "Entity operator compare two entities retrun equals")]
	public void EntityOperator_CompareTwoEntities_RetrunEquals()
	{
		var left = new DummyEntity(1);
		var right = new DummyEntity(1);

		var result = left == right;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Entity operator compare two entities retrun no equals")]
	public void EntityOperator_CompareTwoEntities_RetrunNoEquals()
	{
		var left = new DummyEntity(1);
		var right = new DummyEntity(2);

		var result = left == right;

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity operator compare right entities with left null retrun no equals")]
	public void EntityOperator_CompareRightEntityWithLeftNull_RetrunNoEquals()
	{
		DummyEntity left = null;
		var right = new DummyEntity(2);

		var result = left == right;

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity operator compare left entities with right null retrun no equals")]
	public void EntityOperator_CompareLeftEntityWithRightNull_RetrunNoEquals()
	{
		var left = new DummyEntity(1);
		DummyEntity right = null;

		var result = left == right;

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity operator distinct two entities retrun true")]
	public void EntityOperator_CompareTwoEntities_RetrunTrue()
	{
		var left = new DummyEntity(1);
		var right = new DummyEntity(2);

		var result = left != right;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Entity operator distinct two entities retrun false")]
	public void EntityOperator_DistinctTwoEntities_RetrunFalse()
	{
		var left = new DummyEntity(1);
		var right = new DummyEntity(1);

		var result = left != right;

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity equals compare two entities retrun equals")]
	public void EntityEquals_CompareTwoEntities_RetrunEquals()
	{
		var left = new DummyEntity(1);
		var right = new DummyEntity(1);

		var result = left.Equals(right);

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Entity equals compare two entities retrun no equals")]
	public void EntityEquals_CompareTwoEntities_RetrunNoEquals()
	{
		var left = new DummyEntity(1);
		var right = new DummyEntity(2);

		var result = left.Equals(right);

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity equals compare two entities retrun no equals")]
	public void EntityEquals_CompareLeftNullWithRightEntity_RetrunNoEquals()
	{
		var left = new DummyEntity(1);
		DummyEntity right = null;

		var result = left.Equals(right);

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity equals compare two distinct type entities retrun no equals")]
	public void EntityEquals_CompareTwoDistinctTypeEnities_RetrunNoEquals()
	{
		var left = new DummyEntity(1);
		var right = new DummyOtherEntity(1);

		var result = left.Equals(right);

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Entity equals compare two entities retrun equals")]
	public void EntityEquals_CompareSameEntity_RetrunEquals()
	{
		var left = new DummyEntity(1);

		var result = left.Equals(left);

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Entity equals compare entities by id value retrun equals")]
	public void EntityEquals_CompareEntityByIdValue_RetrunEquals()
	{
		var left = new DummyEntity(1);

		var result = left.Equals(1);

		result.Should().BeTrue();
	}

	private class DummyEntity : Entity<long>
	{
		public DummyEntity(long id)
		{
			Id = id;
		}
	}

	private class DummyOtherEntity : Entity<long>
	{
		public DummyOtherEntity(long id)
		{
			Id = id;
		}
	}
}