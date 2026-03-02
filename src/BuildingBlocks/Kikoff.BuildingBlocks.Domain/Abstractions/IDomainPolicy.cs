namespace Kikoff.BuildingBlocks.Domain.Abstractions;

public interface IDomainPolicy
{
    bool Ensure();
}
