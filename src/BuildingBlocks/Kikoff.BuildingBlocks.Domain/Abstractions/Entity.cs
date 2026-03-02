using System.ComponentModel.DataAnnotations.Schema;
using Kikoff.BuildingBlocks.Domain.Abstractions.Exceptions;

namespace Kikoff.BuildingBlocks.Domain.Abstractions;

public abstract class Entity
{
    private List<DomainEvent>? _domainEvents;

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly() ?? [];

    protected void AddDomainEvent(DomainEvent eventItem)
    {
        _domainEvents ??= [];
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    protected static void Ensure(params IDomainPolicy[] policies)
    {
        var violations = policies
            .Where(x => !x.Ensure())
            .Select(policy => new DomainPolicyViolationException(policy.GetType().Name)).ToList();

        if (violations.Count == 1)
        {
            // unwrap single violation to keep exception type specific
            throw violations[0];
        }
        else if (violations.Count > 1)
        {
            throw new MultipleDomainPoliciesViolatedException(violations);
        }
    }
}
