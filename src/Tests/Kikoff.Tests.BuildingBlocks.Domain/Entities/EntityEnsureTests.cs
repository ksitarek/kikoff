using Kikoff.BuildingBlocks.Domain.Abstractions;
using Kikoff.BuildingBlocks.Domain.Abstractions.Exceptions;

namespace Kikoff.Tests.BuildingBlocks.Domain.Entities;

[Category("Unit")]
[Category("BuildingBlocks")]
public class EntityEnsureTests
{
    [Test]
    public void EnsureWillNotThrowWhenPoliciesAreMet()
    {
        // Act & Assert
        Assert.DoesNotThrow(() => TestEntityA.A(3));
    }

    [Test]
    public void EnsureWillThrowWhenOnePolicyIsViolated()
    {
        // Act & Assert
        DomainPolicyViolationException? ex = Assert.Throws<DomainPolicyViolationException>(() => TestEntityA.A(1));
        Assert.That(ex?.Message, Is.EqualTo("ValueBiggerThanTwoPolicy"));
    }

    [Test]
    public void EnsureWillThrowWhenMultiplePoliciesAreViolated()
    {
        // Act & Assert
        MultipleDomainPoliciesViolatedException? ex =
            Assert.Throws<MultipleDomainPoliciesViolatedException>(() => TestEntityA.A(-1));
        Assert.That(ex?.InnerExceptions, Has.Count.EqualTo(2));
        Assert.That(ex?.InnerExceptions[0].Message, Is.EqualTo("ValueBiggerThanZeroPolicy"));
        Assert.That(ex?.InnerExceptions[1].Message, Is.EqualTo("ValueBiggerThanTwoPolicy"));
    }


    private class TestEntityA : Entity
    {
        public static void A(int value)
        {
            Ensure(
                new ValueBiggerThanZeroPolicy(value),
                new ValueBiggerThanTwoPolicy(value));
        }
    }

    private class ValueBiggerThanZeroPolicy : IDomainPolicy
    {
        private readonly int _value;

        public ValueBiggerThanZeroPolicy(int value)
        {
            _value = value;
        }

        public bool Ensure()
        {
            return _value > 0;
        }
    }

    private class ValueBiggerThanTwoPolicy : IDomainPolicy
    {
        private readonly int _value;

        public ValueBiggerThanTwoPolicy(int value)
        {
            _value = value;
        }

        public bool Ensure()
        {
            return _value > 2;
        }
    }
}
