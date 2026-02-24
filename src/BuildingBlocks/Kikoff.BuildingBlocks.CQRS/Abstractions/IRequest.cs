using Microsoft.AspNetCore.Http;

namespace Kikoff.BuildingBlocks.CQRS.Abstractions;

public interface IRequest;
public interface IRequest<TResult> : IResult;
