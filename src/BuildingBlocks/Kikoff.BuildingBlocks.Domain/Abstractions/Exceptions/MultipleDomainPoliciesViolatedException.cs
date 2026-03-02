namespace Kikoff.BuildingBlocks.Domain.Abstractions.Exceptions;

public sealed class MultipleDomainPoliciesViolatedException : AggregateException
{
    public MultipleDomainPoliciesViolatedException(string message, IEnumerable<Exception> innerExceptions)
        : base(message, innerExceptions)
    {
    }

    public MultipleDomainPoliciesViolatedException(IEnumerable<DomainPolicyViolationException> innerExceptions)
        : base("Multiple domain policies were violated.", innerExceptions)
    {
    }
}
