namespace Kikoff.BuildingBlocks.Domain.Abstractions.Exceptions;

public class DomainPolicyViolationException : Exception
{
    public DomainPolicyViolationException(string message) : base(message)
    {
    }
}
